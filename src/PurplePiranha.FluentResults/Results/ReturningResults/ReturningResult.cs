using PurplePiranha.FluentResults.FailureTypes;
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

        bool IReturningResult<TReturn>.IsFailure => base.IsFailure;

        FailureType? IReturningResult<TReturn>.FailureType => base.FailureType;

        public ReturningResult(FailureType error, Dictionary<string, object>? customProperties = null) : base(error, customProperties)
        {
        }

        public ReturningResult(Result result) : base(result.FailureType, result.CustomProperties)
        {
        }

        public IReturningResultWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func)
        {
            if (IsSuccess)
                _returnValue = func();

            return this;
        }

        public IReturningResultWithOnError<TReturn> OnError(Func<FailureType, TReturn> func)
        {
#nullable disable
            if (IsFailure)
                _returnValue = func(FailureType);
#nullable enable

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }
    }
}
