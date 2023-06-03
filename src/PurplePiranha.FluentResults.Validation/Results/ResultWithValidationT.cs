using FluentValidation.Results;
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
    public class ResultWithValidation<TValue> : ResultBase<TValue>
    {
        #region Ctr
        protected internal ResultWithValidation(TValue? value, Error error, ValidationResult? validationResult = null, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
        {
            if (_customProperties is null)
                _customProperties = new Dictionary<string, object>();

            if (validationResult != null)
                _customProperties.Add(ResultWithValidation.VALIDATION_RESULT_KEY, validationResult);
        }
        #endregion

        #region Operators
        public static implicit operator ResultWithValidation<TValue>(ResultWithValidation result) => new(default, result.Error, null, result.CustomProperties);
        public static implicit operator ResultWithValidation(ResultWithValidation<TValue> result) => new(result.Error, null, result.CustomProperties);
        public static implicit operator ResultWithValidation<TValue>(Result result) => new(default, result.Error, null, result.CustomProperties);
        public static implicit operator ResultWithValidation<TValue>(Result<TValue> result) => new(result.Value, result.Error, null, result.CustomProperties);
        public static implicit operator Result(ResultWithValidation<TValue> result) => new(result.Error, result.CustomProperties);
        #endregion

        #region Properties
        public bool IsValidationFailure => Error == ValidationErrors.ValidationFailure;
        public override bool IsError => _error != Error.None && _error != ValidationErrors.ValidationFailure; // validation failures are not treated as errors

        public ValidationResult? ValidationResult
        {
            get
            {
                var validationResult = _customProperties.GetValueOrDefault(ResultWithValidation.VALIDATION_RESULT_KEY);
                return (ValidationResult?)validationResult;
            }
        }
        #endregion

    }
}
