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
    public class ResultWithValidation : ResultBase
    {
        #region Fields
        protected internal const string VALIDATION_FAILURE_KEY = "ValidationFailure";
        #endregion

        #region Ctr
        protected internal ResultWithValidation(Error error, IEnumerable<string>? validationFailures = null, Dictionary<string, object>? customProperties = null) : base(error, customProperties) 
        { 
            if (_customProperties is null)
                _customProperties = new Dictionary<string, object>();
            
            if (validationFailures != null)
                _customProperties.Add(VALIDATION_FAILURE_KEY, validationFailures ?? new List<string>());
        }
        #endregion

        #region Static create methods
        public static ResultWithValidation SuccessResult() => new(Error.None);
        public static ResultWithValidation ErrorResult(Error error) => new(error);
        public static ResultWithValidation<TValue> SuccessResult<TValue>(TValue value) => new(value, Error.None);
        public static ResultWithValidation<TValue> ErrorResult<TValue>(Error error) => new(default, error);
        public static ResultWithValidation ValidationFailureResult(IEnumerable<string> validationFailures) => new(ValidationErrors.ValidationFailure, validationFailures);

        public static ResultWithValidation<TValue> ValidationFailureResult<TValue>(IEnumerable<string> validationFailures) => new(default, ValidationErrors.ValidationFailure, validationFailures);
        #endregion

        public bool IsValidationFailure => Error == ValidationErrors.ValidationFailure;
        public override bool IsError => _error != Error.None && _error != ValidationErrors.ValidationFailure; // validation failures are not treated as errors

        public IEnumerable<string> ValidationFailures
        {
            get
            {
                var validationErrors = _customProperties.GetValueOrDefault(VALIDATION_FAILURE_KEY);
                return (IEnumerable<string>)(validationErrors ?? Enumerable.Empty<string>());
            }
        }
    }
}
