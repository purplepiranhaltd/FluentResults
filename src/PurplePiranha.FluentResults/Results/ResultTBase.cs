using PurplePiranha.FluentResults.FailureTypes;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase<TValue> : ResultBase
{
    #region Fields
    private readonly TValue? _value;
    #endregion

    #region Ctr
    protected internal ResultBase(TValue? value, Failure failureType, Dictionary<string, object>? customProperties = null) : base(failureType, customProperties) => _value = value;
    #endregion

    #region Properties
    public virtual TValue? Value => _value;
    #endregion
}
