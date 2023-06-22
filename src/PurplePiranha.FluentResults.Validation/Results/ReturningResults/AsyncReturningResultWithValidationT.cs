using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    public class AsyncReturningResultWithValidation<TValue, TReturn> :
        ResultWithValidation<TValue>,
        IAsyncReturningResultWithValidationInitialState<TValue, TReturn>,
        IAsyncReturningResultWithValidationWithOnSuccess<TValue, TReturn>,
        IAsyncReturningResultWithValidationWithOnValidationFailure<TValue, TReturn>,
        IAsyncReturningResultWithValidationWithOnError<TValue, TReturn>
    {
        private Task<TReturn> _returnTask;

        protected internal AsyncReturningResultWithValidation(TValue? value, Error error, ValidationResult? validationResult = null, Dictionary<string, object>? customProperties = null) : base(value, error, validationResult, customProperties)
        {
        }

        public AsyncReturningResultWithValidation(ResultWithValidation<TValue> result) : base(result.Value, result.Error, null, result.CustomProperties)
        { 
        }

        public IAsyncReturningResultWithValidationWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, Task<TReturn>> func)
        {
#nullable disable
            if (this.IsSuccess)
                _returnTask = func(Value);
#nullable enable

            return this;
        }

        public IAsyncReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> OnValidationFailure(Func<ValidationResult, Task<TReturn>> func)
        {
#nullable disable
            if (this.IsValidationFailure)
                _returnTask = func(ValidationResult);
#nullable enable

            return this;
        }

        public IAsyncReturningResultWithValidationWithOnError<TValue, TReturn> OnError(Func<Error, Task<TReturn>> func)
        {
            if (this.IsError)
                _returnTask = func(Error);

            return this;
        }

        public Task<TReturn> ReturnAsync()
        {
            return _returnTask;
        }
    }
}
