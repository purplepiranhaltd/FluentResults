using PurplePiranha.FluentResults.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurplePiranha.FluentResults.Errors;
using FluentValidation.Results;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    internal class AsyncReturningResultWithValidation<TReturn> :
        ResultWithValidation,
        IAsyncReturningResultWithValidationInitialState<TReturn>,
        IAsyncReturningResultWithValidationWithOnSuccess<TReturn>,
        IAsyncReturningResultWithValidationWithOnValidationFailure<TReturn>,
        IAsyncReturningResultWithValidationWithOnError<TReturn>

    {
        private Task<TReturn> _returnTask;

        protected internal AsyncReturningResultWithValidation(Error error, ValidationResult? validationResult = null, Dictionary<string, object>? customProperties = null) : base(error, validationResult, customProperties)
        {
        }

        public AsyncReturningResultWithValidation(ResultWithValidation result) : base(result.Error, null, result.CustomProperties)
        {
        }

        public IAsyncReturningResultWithValidationWithOnSuccess<TReturn> OnSuccess(Func<Task<TReturn>> func)
        {
            if (this.IsSuccess)
                _returnTask = func();

            return this;
        }

        public IAsyncReturningResultWithValidationWithOnValidationFailure<TReturn> OnValidationFailure(Func<ValidationResult, Task<TReturn>> func)
        {
#nullable disable
            if (IsValidationFailure)
                _returnTask = func(ValidationResult);
#nullable enable

            return this;
        }

        public IAsyncReturningResultWithValidationWithOnError<TReturn> OnError(Func<Error, Task<TReturn>> func)
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
