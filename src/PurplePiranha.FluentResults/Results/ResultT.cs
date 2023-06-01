using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public class Result<TValue> : Result
{
    #region Fields
    private readonly TValue? _value;
    #endregion

    #region Ctr
    protected internal Result(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties) => _value = value;

    public Result(Result<TValue> result) : base(result) => _value = result._value;
    #endregion

    #region Public properties
    public virtual TValue? Value => _value;
    #endregion

    #region Operators
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
    #endregion
}
