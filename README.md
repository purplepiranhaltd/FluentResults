![Logo](https://raw.githubusercontent.com/purplepiranhaltd/FluentResults/refs/heads/main/Logo.svg)

# FluentResults
FluentResults allows results to be accessed in a fluent manner to determine their success or failure.

The result object allows the return of 'Success' or 'Failure'. Result objects can be created in the following manner:

```
// A successful result
var result = Result.SuccessResult();

// A success result that has a return value
var result = Result.SuccessResult(57);

// A failure result
var result = Result.FailureResult(new NullValueFailure());
```
Accessing the results is done via the fluent interface:
```
// Results without a return value
result
  .OnSuccess(() => {
    // do something
  })
  .OnFailure(failure => {
    // do something like log the error (held in e) or throw an exception
  });
  
// Results with a return value
result
  .OnSuccess(r => {
    // do something with the result (held in r)
  })
  .OnFailure(failure => {
    // do something like log the error (held in e) or throw an exception
  });
```
# Returning values based on a Result's success or failure
```
// Result without value returning an int based on outcome
var a = result
  .Returning<int>()
  .OnSuccess(() =>
  {
    return 100;
  })
  .OnFailure(failure => {
    return -1;
  })
  .Return();

// Result without value returning an int asynchronously or throwing an exception if there's an error
var b = await result
  .AsyncReturning<int>()
  .OnSuccess(async () =>
  {
    return await GetSomethingAsync();
  })
  .OnFailure(async failure =>
  {
    throw new SomethingWentWrongException(failure);
  })
  .ReturnAsync();

// Result with a value returning that value or throwing an exception if there's an error
var c = result
  .Returning<int>()
  .OnSuccess(v =>
  {
    return v;
  })
  .OnFailure(e => {
    throw new SomethingWentWrongException(e);
  })
  .Return();

// Result used within a Controller method returning IActionResult
[HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
  ...

  return await result
      .AsyncReturningActionResult()
      .OnSuccess(async user => {
          await LoginUser(user);
          return RedirectToAction(nameof(VerifyEmailAddress));
      })
      .OnFailure(async failure => {
          ModelState.AddModelError(string.Empty, "An error occured.");
          return View(model);
      })
      .ReturnAsync()
      ;
}
```

# Defining Failures
It's recommented that you create a base class for failures in your application. For large systems you may also want to go a step further and seperate areas or modules.

```
public abstract class MyApplicationFailure : Failure
{
  public MyApplicationFailure(
    string failureName,
    string message,
    object? obj = null
    ) : base($"Dummy.MyApplication.{failureName}", message, obj) { }
}
```
Failures are then created by extending this class.

The example below shows how you can create a failure from the result of the [FluentValidation](https://www.nuget.org/packages/fluentvalidation/) library.

```
public class ValidationFailure : MyApplicationFailure
{
    public ValidationFailure(ValidationResult validationResult) : base(nameof(ValidationFailure), "Validation failed", validationResult)
    {
    }

    public ValidationResult ValidationResult => (ValidationResult)base.Obj;
}
```
This approach to defining failures allows us to then easily check for a particular failure type.

```
[HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
  ...

  return await result
      .AsyncReturningActionResult()
      .OnSuccess(async user => {
          await LoginUser(user);
          return RedirectToAction(nameof(VerifyEmailAddress));
      })
      .OnFailure(async failure => {

          if (failure is ValidationFailure validationFailure)
          {
              validationFailure.ValidationResult.Errors.ForEach(error => { 
                  ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
              });

            return View(model);
          }

          if (failure is NotAuthorisedFailure)
            return StatusCode(401);

          return StatusCode(500);
      })
      .ReturnAsync();
}
```
