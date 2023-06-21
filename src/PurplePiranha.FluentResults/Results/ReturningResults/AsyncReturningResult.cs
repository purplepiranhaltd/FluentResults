using PurplePiranha.FluentResults.Errors;
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
        IAsyncReturningResultWithOnError<TReturn>

    {
        private Task<TReturn> _returnTask;

        public AsyncReturningResult(Error error, Dictionary<string, object>? customProperties = null) : base(error, customProperties)
        {
        }

        public AsyncReturningResult(Result result) : base(result.Error, result.CustomProperties)
        {
        }

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsError => base.IsError;

        Error? IReturningResult<TReturn>.Error => base.Error;

        public IAsyncReturningResultWithOnError<TReturn> OnError(Func<Error, Task<TReturn>> func)
        {
            if (this.IsError)
                _returnTask = func(Error);

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

        void IAsyncReturningResult<TReturn>.SetReturnTask(Task<TReturn> task)
        {
            _returnTask = task;
        }
    }
}
