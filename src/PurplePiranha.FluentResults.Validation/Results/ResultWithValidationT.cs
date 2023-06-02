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
    public class ResultWithValidation<TValue> : ResultWithValidation
    {
        #region Fields
        private readonly TValue? _value;
        #endregion

        #region Ctr
        protected internal ResultWithValidation(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties) => _value = value;

        public ResultWithValidation(Result<TValue> result) : base(result) => _value = result.Value;
        public ResultWithValidation(Result result) : base(result) => _value = default(TValue);
        public ResultWithValidation(ResultWithValidation<TValue> result) : base(result) => _value = result._value;
        public ResultWithValidation(ResultWithValidation result) : base(result) => _value = default(TValue);
        #endregion

        #region Public properties
        public virtual TValue? Value => _value;
        #endregion

        #region Operators
        public static implicit operator ResultWithValidation<TValue>(TValue? value) => Create(value);
        #endregion

    }
}
