using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public class Result
{
    #region Fields
    protected internal Error _error;
    protected internal Dictionary<string, object> _customProperties; // allows the use of custom properties in derived classes
    #endregion

    #region Ctr
    protected internal Result(Error error, Dictionary<string, object>? customProperties = null)
    {
        _error = error;
        _customProperties = customProperties ?? new Dictionary<string, object>();
    }

    protected internal Result(Result result) : this(result._error, result._customProperties)
    {

    }
    #endregion

    #region Static create methods
    public static Result SuccessResult() => new(Error.None);
    public static Result ErrorResult(Error error) => new(error);
    public static Result<TValue> SuccessResult<TValue>(TValue value) => new Result<TValue>(value, Error.None);
    public static Result<TValue> ErrorResult<TValue>(Error error) => new(default, error);
    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? SuccessResult(value) : ErrorResult<TValue>(Error.NullValue);
    #endregion

    #region Public properties
    public virtual Error Error => _error;

    public Dictionary<string, object> CustomProperties => _customProperties;

    public virtual bool IsSuccess => _error == Error.None;
    
    public virtual bool IsError => _error != Error.None;
    #endregion
}


