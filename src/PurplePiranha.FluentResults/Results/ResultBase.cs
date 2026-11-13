using PurplePiranha.FluentResults.FailureTypes;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase
{
    #region Fields
    protected internal Failure _failure;
    protected internal Dictionary<string, object> _customProperties; // allows the use of custom properties in derived classes
    #endregion

    #region Ctr
    protected internal ResultBase(Failure failure, Dictionary<string, object>? customProperties = null)
    {
        _failure = failure;
        // Copy so results never share (and silently mutate) each other's properties.
        _customProperties = customProperties is null ? new Dictionary<string, object>() : new Dictionary<string, object>(customProperties);
    }

    protected internal ResultBase(ResultBase result)
    {
        _failure = result._failure;
        _customProperties = new Dictionary<string, object>(result._customProperties);
    }
    #endregion

    #region Public properties
    public virtual Failure Failure => _failure;

    public virtual bool IsSuccess => _failure is NoFailure;
    
    public virtual bool IsFailure => _failure is not NoFailure;

    public Dictionary<string,object> CustomProperties => _customProperties;
    #endregion
}


