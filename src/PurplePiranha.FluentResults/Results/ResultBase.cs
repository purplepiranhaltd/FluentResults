using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase
{
    #region Fields
    protected internal Error _error;
    protected internal Dictionary<string, object> _customProperties; // allows the use of custom properties in derived classes
    #endregion

    #region Ctr
    protected internal ResultBase(Error error, Dictionary<string, object>? customProperties = null)
    {
        _error = error;
        _customProperties = customProperties ?? new Dictionary<string, object>();
    }

    protected internal ResultBase(ResultBase result)
    {
        _error = result._error;
        _customProperties = result._customProperties;
    }
    #endregion

    #region Public properties
    public virtual Error Error => _error;

    public virtual bool IsSuccess => _error == Error.None;
    
    public virtual bool IsError => _error != Error.None;

    public Dictionary<string,object> CustomProperties => _customProperties;
    #endregion
}


