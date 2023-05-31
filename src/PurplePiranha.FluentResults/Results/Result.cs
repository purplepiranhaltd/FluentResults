using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public class Result
{
    #region Ctr
    protected internal Result()
    {
        // success
        ResultType = ResultType.Success;
        Error = Error.None;
        ValidationErrors = new List<string>();

    }

    protected internal Result(Error error)
    {
        // error
        ResultType = ResultType.Error;
        Error = error;
        ValidationErrors = new List<string>();
    }

    protected internal Result(IEnumerable<string> validationErrors)
    {
        // validation error(s)
        ResultType = ResultType.ValidationFailure;
        Error = Error.None;
        ValidationErrors = validationErrors;
    }
    #endregion

    #region Static create methods
    public static Result SuccessResult() => new();
    public static Result ErrorResult(Error error) => new(error);
    public static Result ValidationFailureResult(IEnumerable<string> validationErrors) => new(validationErrors);

    public static Result<TValue> SuccessResult<TValue>(TValue value) => new Result<TValue>(value);
    public static Result<TValue> ErrorResult<TValue>(Error error) => new(default, error);
    public static Result<TValue> ValidationFailureResult<TValue>(IEnumerable<string> validationErrors) => new(default, validationErrors);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? SuccessResult(value) : ErrorResult<TValue>(Error.NullValue);
    #endregion

    #region Public properties
    public ResultType ResultType { get; }
    public Error Error { get; }
    public IEnumerable<string> ValidationErrors { get; }

    public bool IsSuccess => ResultType == ResultType.Success;
    public bool IsValidationFailure => ResultType == ResultType.ValidationFailure;
    public bool IsError => ResultType == ResultType.Error;
    #endregion
}
