using PurplePiranha.FluentResults.FailureTypes;
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

        public AsyncReturningResult(TValue? value, FailureType error, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
        {
        }


        public AsyncReturningResult(Result<TValue> result) : base(result.Value, result.FailureType, result.CustomProperties)
        {
        }

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsFailure => base.IsFailure;

        FailureType? IReturningResult<TReturn>.FailureType => base.FailureType;

        public IAsyncReturningResultWithOnError<TValue, TReturn> OnError(Func<FailureType, Task<TReturn>> func)
        {
            if (this.IsFailure)
                _returnTask = func(FailureType);

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
