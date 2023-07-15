namespace PurplePiranha.FluentResults.FailureTypes;

public abstract class Failure : IEquatable<Failure>
{
    public Failure(string code, string message, object? obj = null)
    {
        Code = code;
        Message = message;
        Obj = obj;
    }

    public string Code { get; }

    public string Message { get; }

    protected object? Obj { get; }

    public static implicit operator string(Failure failure) => failure.Code;

    public static bool operator ==(Failure? a, Failure? b)
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

    public static bool operator !=(Failure? a, Failure? b) => !(a == b);

    public virtual bool Equals(Failure? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is Failure failure && Equals(failure);

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}
