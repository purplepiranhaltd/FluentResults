using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Results;

public static class ResultExtensions
{
    public static Result<TValue> ToResult<TValue>(this Result result) => new Result<TValue>(result);

    public static Result OnSuccess(this Result result, Action action)
    {
        if (result.IsSuccess)
            action();

        return result;
    }
    public static Result OnSuccess<T>(this Result<T> result, Action<T?> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return result;
    }

    public static Result OnError(this Result result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }
}
