using PurplePiranha.FluentResults.FailureTypes;
using System.Diagnostics.CodeAnalysis;

namespace PurplePiranha.FluentResults.Results;

public abstract class ResultBase<TValue> : ResultBase
{
    #region Fields
    private readonly TValue? _value;
    #endregion

    #region Ctr
    protected internal ResultBase(TValue? value, Failure failureType, Dictionary<string, object>? customProperties = null) : base(EnsureValueIfSuccess(value, failureType), customProperties) => _value = value;

    // A success must carry a non-null value, otherwise [MemberNotNullWhen] on IsSuccess would be a lie.
    private static Failure EnsureValueIfSuccess(TValue? value, Failure failure)
        => value is null && failure is NoFailure ? new NullValueFailure() : failure;
    #endregion

    #region Properties
    public virtual TValue? Value => _value;

    [MemberNotNullWhen(true, nameof(Value))]
    public override bool IsSuccess => base.IsSuccess;

    [MemberNotNullWhen(false, nameof(Value))]
    public override bool IsFailure => base.IsFailure;
    #endregion
}
