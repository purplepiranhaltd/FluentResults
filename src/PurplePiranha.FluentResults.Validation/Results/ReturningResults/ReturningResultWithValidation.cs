using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Validation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    public class ReturningResultWithValidation<TReturn> :
        ResultWithValidation,
        IReturningResultWithValidationInitialState<TReturn>,
        IReturningResultWithValidationWithOnSuccess<TReturn>,
        IReturningResultWithValidationWithOnValidationFailure<TReturn>,
        IReturningResultWithValidationWithOnError<TReturn>
    {
        private TReturn _returnValue;

        bool IReturningResultWithValidation<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResultWithValidation<TReturn>.IsError => base.IsError;

        Error? IReturningResultWithValidation<TReturn>.Error => base.Error;

        public ReturningResultWithValidation(Error error, Dictionary<string, object>? customProperties = null) : base(error, null, customProperties)
        {
        }

        public ReturningResultWithValidation(ResultWithValidation result) : base(result.Error, null, result.CustomProperties)
        {
        }

        public IReturningResultWithValidationWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func)
        {
            if (IsSuccess)
                _returnValue = func();

            return this;
        }

        public IReturningResultWithValidationWithOnValidationFailure<TReturn> OnValidationFailure(Func<ValidationResult, TReturn> func)
        {
#nullable disable
            if (IsValidationFailure)
                _returnValue = func(ValidationResult);
#nullable enable

            return this;
        }

        public IReturningResultWithValidationWithOnError<TReturn> OnError(Func<Error, TReturn> func)
        {
#nullable disable
            if (IsError)
                _returnValue = func(Error);
#nullable enable

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }
    }
}
