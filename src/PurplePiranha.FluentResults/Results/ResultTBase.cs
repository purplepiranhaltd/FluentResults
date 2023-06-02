using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase<TValue> : ResultBase
{
    #region Fields
    private readonly TValue? _value;
    #endregion

    #region Ctr
    protected internal ResultBase(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties) => _value = value;

    //public Result(Result<TValue> result) : base(result) => _value = result._value;

    //public Result(Result result) : base(result) => _value = default(TValue);
    #endregion

    #region Properties
    public virtual TValue? Value => _value;
    #endregion
}
