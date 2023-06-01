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
        //#region Ctr
        //protected internal ResultWithValidation(TValue? value, Error error, Dictionary<string, object> customProperties) : base(value, error, customProperties) { }
        //protected internal ResultWithValidation(Result<TValue> result) : base(result) { }
        //#endregion

        //#region Public properties
        //public override TValue Value =>
        //    base.Error == ValidationErrors.ValidationFailure ? throw new InvalidOperationException("The value of a validation failure result can not be accessed.") : base.Value;
        //#endregion

        #region Fields
        private readonly TValue? _value;
        #endregion

        #region Ctr
        protected internal ResultWithValidation(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties) => _value = value;

        protected internal ResultWithValidation(Result<TValue> result) : base(result)
        {
            _error = result.Error;
            _customProperties = result.CustomProperties;

            if (result.Error == Error.None)
                _value = result.Value;
        }
        #endregion

        #region Public properties
        public virtual TValue? Value => _value;
        #endregion

        //#region Operators
        //public static implicit operator ResultWithValidation<TValue>(TValue? value) => Create(value);
        //#endregion

    }
}
