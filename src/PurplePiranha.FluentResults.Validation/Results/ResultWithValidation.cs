using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results
{
    public class ResultWithValidation : Result
    {
        protected internal const string VALIDATION_FAILURE_KEY = "ValidationFailure";
        protected internal ResultWithValidation(Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties) { }

        public ResultWithValidation(Result result) : base(result) { }

        public new static ResultWithValidation SuccessResult() => new ResultWithValidation(Result.SuccessResult());
        public new static ResultWithValidation ErrorResult(Error error) => new ResultWithValidation(Result.ErrorResult(error));
        public new static ResultWithValidation<TValue> SuccessResult<TValue>(TValue value) => new ResultWithValidation<TValue>(Result.SuccessResult<TValue>(value));
        public new static ResultWithValidation<TValue> ErrorResult<TValue>(Error error) => new ResultWithValidation<TValue>(Result.ErrorResult<TValue>(error));

        public static ResultWithValidation ValidationFailureResult(IEnumerable<string> validationFailures) => new(ValidationErrors.ValidationFailure, CreateCustomProperties(validationFailures));

        public static ResultWithValidation<TValue> ValidationFailureResult<TValue>(IEnumerable<string> validationFailures) => new(default, ValidationErrors.ValidationFailure, CreateCustomProperties(validationFailures));

        ////public new static ResultWithValidation<TValue> Create<TValue>(TValue? value) => value is not null ? SuccessResult(value) : ErrorResult<TValue>(Error.NullValue);

        public bool IsValidationFailure => Error == ValidationErrors.ValidationFailure;
        public override bool IsError => _error != Error.None && _error != ValidationErrors.ValidationFailure; // validation failures are not treated as errors
                                                                                                              // but will be if casted to the Result class

        public IEnumerable<string> ValidationFailures { 
            get { 
                var validationErrors = _customProperties.GetValueOrDefault(VALIDATION_FAILURE_KEY);
                return (IEnumerable<string>)(validationErrors ?? Enumerable.Empty<string>());
            } 
        }

        private static Dictionary<string, object> CreateCustomProperties(IEnumerable<string> validationErrors)
        {
            var customProperties = new Dictionary<string, object>();
            customProperties.Add(VALIDATION_FAILURE_KEY, validationErrors);
            return customProperties;
        }
    }
}
