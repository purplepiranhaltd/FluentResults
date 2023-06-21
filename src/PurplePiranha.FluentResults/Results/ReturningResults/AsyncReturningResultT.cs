using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    public class AsyncReturningResult<TValue, TReturn> :
        Result<TValue>,
        IAsyncReturningResultInitialState<TValue, TReturn>,
        IAsyncReturningResultWithOnSuccess<TValue, TReturn>,
        IAsyncReturningResultWithOnError<TValue, TReturn>

    {
        private Task<TReturn> _returnTask;

        public AsyncReturningResult(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
        {
        }


        public AsyncReturningResult(Result<TValue> result) : base(result.Value, result.Error, result.CustomProperties)
        {
        }

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsError => base.IsError;

        Error? IReturningResult<TReturn>.Error => base.Error;

        public IAsyncReturningResultWithOnError<TValue, TReturn> OnError(Func<Error, Task<TReturn>> func)
        {
            if (this.IsError)
                _returnTask = func(Error);

            return this;
        }

        public IAsyncReturningResultWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, Task<TReturn>> func)
        {
#nullable disable
            if (this.IsSuccess)
                _returnTask = func(Value);
#nullable enable

            return this;
        }

        public Task<TReturn> ReturnAsync()
        {
            return _returnTask;
        }
    }
}
