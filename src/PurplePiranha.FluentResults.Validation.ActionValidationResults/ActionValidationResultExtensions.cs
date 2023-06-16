using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Validation.Results;

namespace PurplePiranha.FluentResults.Validation.ActionValidationResults
{
    public static class ActionValidationResultExtensions
    {
        public static Task<IActionValidationResult<T>> AsActionValidationResult<T>(this ResultWithValidation<T> result)
        {
            return Task.FromResult((IActionValidationResult<T>)new ActionValidationResult<T>(result));
        }

        public static async Task<IActionValidationResultWithOnSuccess<T>> OnSuccess<T>(this Task<IActionValidationResult<T>> resultTask, Func<T, Task<IActionResult>> action)
        {
            var result = await resultTask;
#nullable disable
            if (result.IsSuccess)
                result.SetActionResult(await action(result.Value));
#nullable enable
            return (IActionValidationResultWithOnSuccess<T>)result;
        }

        public static async Task<IActionValidationResultWithOnValidationFailure<T>> OnValidationFailure<T>(this Task<IActionValidationResultWithOnSuccess<T>> resultTask, Func<ValidationResult, Task<IActionResult>> action)
        {
            var result = await resultTask;
#nullable disable
            if (result.IsValidationFailure)
                result.SetActionResult(await action(result.ValidationResult));
#nullable enable
            return (IActionValidationResultWithOnValidationFailure<T>)result;
        }

        public static async Task<IActionValidationResultWithOnError<T>> OnError<T>(this Task<IActionValidationResultWithOnValidationFailure<T>> resultTask, Func<Error, Task<IActionResult>> action)
        {
            var result = await resultTask;
#nullable disable
            if (result.IsError)
                result.SetActionResult(await action(result.Error));
#nullable enable
            return (IActionValidationResultWithOnError<T>)result;
        }

        public static async Task<IActionResult> ActionResult<T>(this Task<IActionValidationResultWithOnError<T>> resultTask)
        {
            var result = await resultTask;
            return result.GetActionResult();
        }


    }
}
