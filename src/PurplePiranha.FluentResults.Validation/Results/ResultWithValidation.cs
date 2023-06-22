using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Errors;
using PurplePiranha.FluentResults.Validation.Results.ReturningResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results
{
    public class ResultWithValidation : ResultBase
    {
        #region Fields
        protected internal const string VALIDATION_RESULT_KEY = "ValidationResult";
        #endregion

        #region Ctr
        protected internal ResultWithValidation(Error error, ValidationResult? validationResult = null, Dictionary<string, object>? customProperties = null) : base(error, customProperties) 
        { 
            if (_customProperties is null)
                _customProperties = new Dictionary<string, object>();
            
            if (validationResult is not null)
                _customProperties.Add(VALIDATION_RESULT_KEY, validationResult);
        }
        #endregion

        #region Static create methods
        public static ResultWithValidation SuccessResult(ValidationResult? validationResult = null) => new(Error.None, validationResult);
        public static ResultWithValidation ErrorResult(Error error, ValidationResult? validationResult = null) => new(error, validationResult);
        public static ResultWithValidation<TValue> SuccessResult<TValue>(TValue value, ValidationResult? validationResult = null) => new(value, Error.None, validationResult);
        public static ResultWithValidation<TValue> ErrorResult<TValue>(Error error, ValidationResult? validationResult = null) => new(default, error, validationResult);
        public static ResultWithValidation ValidationFailureResult(ValidationResult validationResult) => new(ValidationErrors.ValidationFailure, validationResult);

        public static ResultWithValidation<TValue> ValidationFailureResult<TValue>(ValidationResult validationResult) => new(default, ValidationErrors.ValidationFailure, validationResult);
        #endregion

        public bool IsValidationFailure => Error == ValidationErrors.ValidationFailure;
        public override bool IsError => _error != Error.None && _error != ValidationErrors.ValidationFailure; // validation failures are not treated as errors

        public ValidationResult? ValidationResult
        {
            get
            {
                var validationResult = _customProperties.GetValueOrDefault(VALIDATION_RESULT_KEY);
                return (ValidationResult?)validationResult;
            }
        }

        #region Operators
        public static implicit operator ResultWithValidation(Result result) => new(result.Error, null, result.CustomProperties);
        #endregion

        #region Returning Results
        public IReturningResultWithValidationInitialState<TReturn> Returning<TReturn>()
        {
            return new ReturningResultWithValidation<TReturn>(this);
        }

        public IAsyncReturningResultWithValidationInitialState<TReturn> AsyncReturning<TReturn>()
        {
            return new AsyncReturningResultWithValidation<TReturn>(this);
        }
        #endregion
    }
}
