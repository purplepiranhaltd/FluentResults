using Microsoft.AspNetCore.Mvc;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults.ActionResults
{
    public static class ResultExtensions
    {
        public static IReturningResultWithValidationInitialState<IActionResult> ReturningActionResult(this ResultWithValidation result)
        {
            return result.Returning<IActionResult>();
        }

        public static IAsyncReturningResultWithValidationInitialState<IActionResult> AsyncReturningActionResult(this ResultWithValidation result)
        {
            return result.AsyncReturning<IActionResult>();
        }

        public static IReturningResultWithValidationInitialState<TValue, IActionResult> ReturningActionResult<TValue>(this ResultWithValidation<TValue> result)
        {
            return result.Returning<IActionResult>();
        }

        public static IAsyncReturningResultWithValidationInitialState<TValue, IActionResult> AsyncReturningActionResult<TValue>(this ResultWithValidation<TValue> result)
        {
            return result.AsyncReturning<IActionResult>();
        }
    }
}
