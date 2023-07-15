namespace PurplePiranha.FluentResults.FailureTypes;

public class FailureType : IEquatable<FailureType>
{
    public static readonly FailureType None = new(string.Empty, string.Empty);
    public static readonly FailureType NullValue = new($"{nameof(FailureType)}.{nameof(NullValue)}", "The specified result value is null.");

    public FailureType(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static implicit operator string(FailureType error) => error.Code;

    public static bool operator ==(FailureType? a, FailureType? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(FailureType? a, FailureType? b) => !(a == b);

    public virtual bool Equals(FailureType? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is FailureType error && Equals(error);

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}
