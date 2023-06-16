using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.Errors;

namespace PurplePiranha.FluentResults.Validation.ActionValidationResults
{
    public interface IActionValidationResult<T>
    {
        bool IsSuccess { get; }
        bool IsValidationFailure { get; }
        bool IsError { get; }
        T? Value { get; }
        ValidationResult? ValidationResult { get; }
        Error? Error { get; }
        internal void SetActionResult(IActionResult actionResult);
        internal IActionResult GetActionResult();
    }
    public interface IActionValidationResultWithOnSuccess<T> : IActionValidationResult<T>
    {

    }

    public interface IActionValidationResultWithOnValidationFailure<T> : IActionValidationResult<T>
    {

    }

    public interface IActionValidationResultWithOnError<T> : IActionValidationResult<T>
    {
    }
}
