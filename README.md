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

# Returning an IActionResult when using a ResultWithValidation in a controller
An 'ActionValidationResult' is available in the 'Validation.ActionValidationResults' package.

This gives us the ability to convert an existing ResultWithValidation to an 'ActionValidationResult' so that we can easily return from a controller action in a fluent manner.

Note: Currently this is only available for results return a value (ResultWithValidation<T>).
```
// Convert ResultWithValidation to ActionValidationResult
var myResultWithValidation = ResultWithValidation.SuccessResult(1000);      // or VailidationFailureResult/ErrorResult
var myActionValidationResult = myResultWithValidation.AsActionValidationResult();

// Return correct IActionResult from controller
public async Task<IActionResult> DoSomething(DoSomethingViewModel model)
{
  ...
  return await result
    .OnSuccess(async v => {
        await DoSomethingElse(v);
        return RedirectToAction("MyCrazyAction");
    })
    .OnValidationFailure(async vf => {
        foreach (var f in vf.Errors)
        {
            ModelState.AddModelError(string.Empty, f.ErrorMessage);
        }

        return View(model);
    })
    .OnError(async e => {
        ModelState.AddModelError(string.Empty, "An error occured.");
        return View(model);
    })
    .ActionResult()
    ;
}
