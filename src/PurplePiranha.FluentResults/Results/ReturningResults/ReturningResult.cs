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
        IReturningResultWithOnFailure<TReturn>
    {
        private TReturn _returnValue;

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsFailure => base.IsFailure;

        Failure? IReturningResult<TReturn>.Failure => base.Failure;

        public ReturningResult(Failure failure, Dictionary<string, object>? customProperties = null) : base(failure, customProperties)
        {
        }

        public ReturningResult(Result result) : base(result.Failure, result.CustomProperties)
        {
        }

        public IReturningResultWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func)
        {
            if (IsSuccess)
                _returnValue = func();

            return this;
        }

        public IReturningResultWithOnFailure<TReturn> OnFailure(Func<Failure, TReturn> func)
        {
#nullable disable
            if (IsFailure)
                _returnValue = func(Failure);
#nullable enable

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }
    }
}
