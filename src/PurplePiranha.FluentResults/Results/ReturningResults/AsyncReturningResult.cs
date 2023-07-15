using PurplePiranha.FluentResults.FailureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    public class AsyncReturningResult<TReturn> :
        Result,
        IAsyncReturningResultInitialState<TReturn>,
        IAsyncReturningResultWithOnSuccess<TReturn>,
        IAsyncReturningResultWithOnFailure<TReturn>

    {
        private Task<TReturn> _returnTask;

        public AsyncReturningResult(Failure failure, Dictionary<string, object>? customProperties = null) : base(failure, customProperties)
        {
        }

        public AsyncReturningResult(Result result) : base(result.Failure, result.CustomProperties)
        {
        }

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsFailure => base.IsFailure;

        Failure? IReturningResult<TReturn>.Failure => base.Failure;

        public IAsyncReturningResultWithOnFailure<TReturn> OnFailure(Func<Failure, Task<TReturn>> func)
        {
            if (this.IsFailure)
                _returnTask = func(Failure);

            return this;
        }

        public IAsyncReturningResultWithOnSuccess<TReturn> OnSuccess(Func<Task<TReturn>> func)
        {
            if (this.IsSuccess)
                _returnTask = func();

            return this;
        }

        public Task<TReturn> ReturnAsync()
        {
            return _returnTask;
        }
    }
}
