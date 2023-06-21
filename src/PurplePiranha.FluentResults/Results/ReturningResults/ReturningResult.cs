using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    public class ReturningResult<TReturn> : 
        Result,
        IReturningResultInitialState<TReturn>,
        IReturningResultWithOnSuccess<TReturn>,
        IReturningResultWithOnError<TReturn>
    {
        private TReturn _returnValue;

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsError => base.IsError;

        Error? IReturningResult<TReturn>.Error => base.Error;

        public ReturningResult(Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties)
        {
        }

        public ReturningResult(Result result) : base(result.Error, result.CustomProperties)
        {
        }

        public IReturningResultWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func)
        {
            if (IsSuccess)
                _returnValue = func();

            return this;
        }

        public IReturningResultWithOnError<TReturn> OnError(Func<Error, TReturn> func)
        {
#nullable disable
            if (IsError)
                _returnValue = func(Error);
#nullable enable

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }
    }
}
