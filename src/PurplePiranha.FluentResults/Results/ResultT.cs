using PurplePiranha.FluentResults.FailureTypes;
using PurplePiranha.FluentResults.Results.ReturningResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results
{
    public class Result<TValue> : ResultBase<TValue>
    {
        public Result(TValue? value, FailureType failureType, Dictionary<string, object>? customProperties = null) : base(value, failureType, customProperties) { }

        #region Operators
        public static implicit operator Result<TValue>(Result result) => new(default, result._failureType, result._customProperties);
        public static implicit operator Result(Result<TValue> result) => new(result._failureType, result._customProperties);
        #endregion

        #region Returning Results
        public IReturningResultInitialState<TValue, TReturn> Returning<TReturn>()
        {
            return new ReturningResult<TValue, TReturn>(this);
        }

        public IAsyncReturningResultInitialState<TValue, TReturn> AsyncReturning<TReturn>()
        {
            return new AsyncReturningResult<TValue, TReturn>(this);
        }
        #endregion
    }
}
