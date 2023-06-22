using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    public class ReturningResultWithValidation<TValue, TReturn> :
        ResultWithValidation<TValue>,
        IReturningResultWithValidationInitialState<TValue, TReturn>,
        IReturningResultWithValidationWithOnSuccess<TValue, TReturn>,
        IReturningResultWithValidationWithOnValidationFailure<TValue, TReturn>,
        IReturningResultWithValidationWithOnError<TValue, TReturn>
    {
        private TReturn _returnValue;

        public ReturningResultWithValidation(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(value, error, null, customProperties)
        {
        }

        public ReturningResultWithValidation(ResultWithValidation<TValue> result) : base(result.Value, result.Error, null, result.CustomProperties)
        {
        }

        public IReturningResultWithValidationWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, TReturn> func)
        {
#nullable disable
            if (IsSuccess)
                _returnValue = func(Value);
#nullable enable

            return this;
        }

        public IReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> OnValidationFailure(Func<ValidationResult, TReturn> func)
        {
#nullable disable
            if (IsValidationFailure)
                _returnValue = func(ValidationResult);
#nullable enable

            return this;
        }

        public IReturningResultWithValidationWithOnError<TValue, TReturn> OnError(Func<Error, TReturn> func)
        {
            if (IsError)
                _returnValue = func(Error);

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }

        
    }
}
