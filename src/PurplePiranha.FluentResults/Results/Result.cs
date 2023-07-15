using PurplePiranha.FluentResults.FailureTypes;
using PurplePiranha.FluentResults.Results.ReturningResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results
{
    public class Result : ResultBase
    {
        #region Ctr
        public Result(FailureType failureType, Dictionary<string, object>? customProperties = null) : base(failureType, customProperties)
        {
        }
        #endregion

        #region Static create methods
        public static Result SuccessResult() => new(FailureType.None);
        public static Result FailureResult(FailureType error) => new(error);
        public static Result<TValue> SuccessResult<TValue>(TValue value) => new(value, FailureType.None);
        public static Result<TValue> FailureResult<TValue>(FailureType error) => new(default, error);
        #endregion

        #region Returning Results
        public IReturningResultInitialState<TReturn> Returning<TReturn>()
        {
            return new ReturningResult<TReturn>(this);
        }

        public IAsyncReturningResultInitialState<TReturn> AsyncReturning<TReturn>()
        {
            return new AsyncReturningResult<TReturn>(this);
        }
        #endregion
    }
}
