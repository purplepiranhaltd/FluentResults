using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results
{
    public class Result<TValue> : ResultBase<TValue>
    {
        public Result(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties) { }

        #region Operators
        public static implicit operator Result<TValue>(Result result) => new(default, result._error, result._customProperties);
        public static implicit operator Result(Result<TValue> result) => new(result._error, result._customProperties);
        #endregion
    }
}
