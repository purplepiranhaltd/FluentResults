using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public static class ResultExtensions
{
    public static ResultBase OnSuccess(this ResultBase result, Action action)
    {
        if (result.IsSuccess)
            action();

        return result;
    }
    public static ResultBase<T> OnSuccess<T>(this ResultBase<T> result, Action<T?> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return result;
    }

    public static ResultBase OnError(this ResultBase result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }

    public static ResultBase<T> OnError<T>(this ResultBase<T> result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }
}
