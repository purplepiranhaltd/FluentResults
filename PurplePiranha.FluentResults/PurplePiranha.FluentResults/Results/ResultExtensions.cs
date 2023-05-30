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

    public static Result OnValidationFailure(this Result result, Action<IEnumerable<string>> action)
    {
        if (result.IsValidationFailure)
            action(result.ValidationErrors);

        return result;
    }

    public static Result OnError(this Result result, Action<Error> action)
    {
        if (result.IsError)
            action(result.Error);

        return result;
    }
}
