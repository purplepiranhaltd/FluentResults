using PurplePiranha.FluentResults.Errors;

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

    public static Result OnError(this Result result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }

    public static Result<T> OnError<T>(this Result<T> result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }
}
