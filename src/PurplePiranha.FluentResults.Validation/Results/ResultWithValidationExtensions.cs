using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results
{
    public static class ResultWithValidationExtensions
    {
        public static ResultWithValidation OnSuccess(this ResultWithValidation result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }
        public static ResultWithValidation<T> OnSuccess<T>(this ResultWithValidation<T> result, Action<T> action)
        {
#nullable disable
            if (result.IsSuccess)
                action(result.Value);
#nullable enable
            return result;
        }

        public static ResultWithValidation OnError(this ResultWithValidation result, Action<Error> action)
        {
            if (result.IsError)
                action(result.Error);

            return result;
        }

        public static ResultWithValidation<T> OnError<T>(this ResultWithValidation<T> result, Action<Error> action)
        {
            if (result.IsError)
                action(result.Error);

            return result;
        }

        public static ResultWithValidation OnValidationFailure(this ResultWithValidation result, Action<ValidationResult> action)
        {
#nullable disable
            if (result.IsValidationFailure)
                action(result.ValidationResult);
#nullable enable
            return result;
        }

        public static ResultWithValidation<T> OnValidationFailure<T>(this ResultWithValidation<T> result, Action<ValidationResult> action)
        {
#nullable disable
            if (result.IsValidationFailure)
                action(result.ValidationResult);
#nullable enable
            return result;
        }
    }
}
