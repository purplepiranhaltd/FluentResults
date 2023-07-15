using PurplePiranha.FluentResults.FailureTypes;

namespace PurplePiranha.FluentResults.Results;

public static class ResultExtensions
{
    public static Result OnSuccess(this Result result, Action action)
    {
        if (result.IsSuccess)
            action();

        return result;
    }
    public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
    {
#nullable disable
        if (result.IsSuccess)
            action(result.Value);
#nullable enable
        return result;
    }

    public static Result OnFailure(this Result result, Action<FailureType> action)
    {
        if (result.IsFailure)
            action(result.FailureType);

        return result;
    }

    public static Result<T> OnFailure<T>(this Result<T> result, Action<FailureType> action)
    {
        if (result.IsFailure)
            action(result.FailureType);

        return result;
    }
}
