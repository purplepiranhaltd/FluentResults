using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Validation.Results;

namespace PurplePiranha.FluentResults.Validation.ActionValidationResults
{
    public class ActionValidationResult<T>
        : ResultWithValidation<T>,
        IActionValidationResult<T>,
        IActionValidationResultWithOnSuccess<T>,
        IActionValidationResultWithOnValidationFailure<T>,
        IActionValidationResultWithOnError<T>
    {
        private IActionResult? _actionResult;

        public ActionValidationResult(ResultWithValidation<T> result)
            : base(result.Value, result.Error, null, result.CustomProperties)
        {
        }

        bool IActionValidationResult<T>.IsSuccess => base.IsSuccess;
        bool IActionValidationResult<T>.IsValidationFailure => base.IsValidationFailure;
        bool IActionValidationResult<T>.IsError => base.IsError;

        T? IActionValidationResult<T>.Value => base.Value;

        ValidationResult? IActionValidationResult<T>.ValidationResult => base.ValidationResult;

        Error? IActionValidationResult<T>.Error => base.Error;

        IActionResult IActionValidationResult<T>.GetActionResult()
        {
            if (_actionResult is null)
                throw new ArgumentNullException(nameof(_actionResult));

            return _actionResult;
        }

        void IActionValidationResult<T>.SetActionResult(IActionResult actionResult)
        {
            _actionResult = actionResult;
        }
    }
}
