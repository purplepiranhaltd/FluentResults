using PurplePiranha.FluentResults.Errors;
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
        public Result(Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties)
        {
        }
        #endregion

        #region Static create methods
        public static Result SuccessResult() => new(Error.None);
        public static Result ErrorResult(Error error) => new(error);
        public static Result<TValue> SuccessResult<TValue>(TValue value) => new(value, Error.None);
        public static Result<TValue> ErrorResult<TValue>(Error error) => new(default, error);
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
