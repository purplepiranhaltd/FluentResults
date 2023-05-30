# FluentResults
FluentResults allows results to be accessed in a fluent manner to determine their success or failure.

The result object allows the return of 'Success', 'Error' or 'Validation Failure'. Result objects can be created in the following manner:

```
// A successful result
var result = Result.SuccessResult();

// A success result that has a return value
var result = Result.SuccessResult(57);

// An error result
var result = Result.ErrorResult(Error.NullValue);

// A validation failure result
var validationErrors = new List<string>();
validationErrors.Add("Email address is required.");
validationErrors.Add("Password does not meet complexity requirements.");
var validationFailureResult = Result.ValidationFailureResult(validationErrors);
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
