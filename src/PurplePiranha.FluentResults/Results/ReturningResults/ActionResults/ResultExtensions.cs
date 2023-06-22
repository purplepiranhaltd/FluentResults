using Microsoft.AspNetCore.Mvc;

namespace PurplePiranha.FluentResults.Results.ReturningResults.ActionResults
{
    public static class ResultExtensions
    {
        public static IReturningResultInitialState<IActionResult> ReturningActionResult(this Result result)
        {
            return result.Returning<IActionResult>();
        }

        public static IAsyncReturningResultInitialState<IActionResult> AsyncReturningActionResult(this Result result)
        {
            return result.AsyncReturning<IActionResult>();
        }

        public static IReturningResultInitialState<TValue, IActionResult> ReturningActionResult<TValue>(this Result<TValue> result)
        {
            return result.Returning<IActionResult>();
        }

        public static IAsyncReturningResultInitialState<TValue, IActionResult> AsyncReturningActionResult<TValue>(this Result<TValue> result)
        {
            return result.AsyncReturning<IActionResult>();
        }
    }
}
