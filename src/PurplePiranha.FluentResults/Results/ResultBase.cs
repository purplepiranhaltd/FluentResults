using PurplePiranha.FluentResults.FailureTypes;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase
{
    #region Fields
    protected internal FailureType _failureType;
    protected internal Dictionary<string, object> _customProperties; // allows the use of custom properties in derived classes
    #endregion

    #region Ctr
    protected internal ResultBase(FailureType error, Dictionary<string, object>? customProperties = null)
    {
        _failureType = error;
        _customProperties = customProperties ?? new Dictionary<string, object>();
    }

    protected internal ResultBase(ResultBase result)
    {
        _failureType = result._failureType;
        _customProperties = result._customProperties;
    }
    #endregion

    #region Public properties
    public virtual FailureType FailureType => _failureType;

    public virtual bool IsSuccess => _failureType == FailureType.None;
    
    public virtual bool IsFailure => _failureType != FailureType.None;

    public Dictionary<string,object> CustomProperties => _customProperties;
    #endregion
}


