using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public class Result<TValue> : Result
{
    #region Fields
    private readonly TValue? _value;
    #endregion

    #region Ctr
    protected internal Result(TValue? value) : base() => _value = value;
    protected internal Result(TValue? value, Error error) : base(error) => _value = value;
    protected internal Result(TValue? value, IEnumerable<string> validationErrors) : base(validationErrors) => _value = value;
    #endregion

    #region Public properties
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    #endregion

    #region Operators
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
    #endregion
}
