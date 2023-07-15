# FluentResults
FluentResults allows results to be accessed in a fluent manner to determine their success or failure.

The result object allows the return of 'Success' or 'Error'. Result objects can be created in the following manner:

```
// A successful result
var result = Result.SuccessResult();

// A success result that has a return value
var result = Result.SuccessResult(57);

// An error result
var result = Result.ErrorResult(Error.NullValue);
```
Accessing the results is done via the fluent interface:
```
// Results without a return value
result
  .OnSuccess(() => {
    // do something
  })
  .OnError(e => {
    // do something like log the error (held in e) or throw an exception
  });
  
// Results with a return value
result
  .OnSuccess(r => {
    // do something with the result (held in r)
  })
  .OnError(e => {
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
  .OnError(e => {
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
  .OnError(async e =>
  {
    throw new SomethingWentWrongException(e);
  })
  .ReturnAsync();

// Result with a value returning that value or throwing an exception if there's an error
var c = result
  .Returning<int>()
  .OnSuccess(v =>
  {
    return v;
  })
  .OnError(e => {
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
      .OnError(async e => {
          ModelState.AddModelError(string.Empty, "An error occured.");
          return View(model);
      })
      .ReturnAsync()
      ;
}
```

# Validation
A 'ResultWithValidation' available in the 'Validation' package is a special kind of Result that contains validation failures.
```
// Create a validation failure result
var validationErrors = new List<string>();
validationErrors.Add("Email address is required.");
validationErrors.Add("Password does not meet complexity requirements.");
var validationFailureResult = ResultWithValidation.ValidationFailureResult(validationErrors);
```
Accessing the results is done via the fluent interface:
```
// Results without a return value
result
  .OnSuccess(() => {
    // do something
  })
  .OnValidationFailure(v => {
    // report back to user validation failures (held in v)
  })
  .OnError(e => {
    // do something like log the error (held in e) or throw an exception
  });
  
// Results with a return value
result
  .OnSuccess(r => {
    // do something with the result (held in r)
  })
  .OnValidationFailure(v => {
    // report back to user validation failures (held in v)
  })
  .OnError(e => {
    // do something like log the error (held in e) or throw an exception
  });
```
