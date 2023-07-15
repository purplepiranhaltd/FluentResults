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
        public Result(Failure failure, Dictionary<string, object>? customProperties = null) : base(failure, customProperties)
        {
        }
        #endregion

        #region Static create methods
        public static Result SuccessResult() => new(new NoFailure());
        public static Result FailureResult(Failure failure) => new(failure);
        public static Result<TValue> SuccessResult<TValue>(TValue value) => new(value, new NoFailure());
        public static Result<TValue> FailureResult<TValue>(Failure failure) => new(default, failure);
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
