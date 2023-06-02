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
        protected internal ResultWithValidation(TValue? value, Error error, IEnumerable<string>? validationFailures = null, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
        {
            if (_customProperties is null)
                _customProperties = new Dictionary<string, object>();

            if (validationFailures != null)
                _customProperties.Add(ResultWithValidation.VALIDATION_FAILURE_KEY, validationFailures ?? new List<string>());
        }
        #endregion

        #region Operators
        public static implicit operator ResultWithValidation<TValue>(ResultWithValidation result) => new(default, result.Error, null, result.CustomProperties);
        public static implicit operator ResultWithValidation(ResultWithValidation<TValue> result) => new(result.Error, null, result.CustomProperties);
        public static implicit operator ResultWithValidation<TValue>(Result result) => new(default, result.Error, null, result.CustomProperties);
        public static implicit operator Result(ResultWithValidation<TValue> result) => new(result.Error, result.CustomProperties);
        #endregion

        #region Properties
        public bool IsValidationFailure => Error == ValidationErrors.ValidationFailure;
        public override bool IsError => _error != Error.None && _error != ValidationErrors.ValidationFailure; // validation failures are not treated as errors

        public IEnumerable<string> ValidationFailures
        {
            get
            {
                var validationErrors = _customProperties.GetValueOrDefault(ResultWithValidation.VALIDATION_FAILURE_KEY);
                return (IEnumerable<string>)(validationErrors ?? Enumerable.Empty<string>());
            }
        }
        #endregion

    }
}
