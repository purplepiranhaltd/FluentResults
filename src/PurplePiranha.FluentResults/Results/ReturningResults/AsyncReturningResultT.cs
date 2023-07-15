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
        IAsyncReturningResultWithOnFailure<TValue, TReturn>

    {
        private Task<TReturn> _returnTask;

        public AsyncReturningResult(TValue? value, Failure failure, Dictionary<string, object>? customProperties = null) : base(value, failure, customProperties)
        {
        }


        public AsyncReturningResult(Result<TValue> result) : base(result.Value, result.Failure, result.CustomProperties)
        {
        }

        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

        bool IReturningResult<TReturn>.IsFailure => base.IsFailure;

        Failure? IReturningResult<TReturn>.Failure => base.Failure;

        public IAsyncReturningResultWithOnFailure<TValue, TReturn> OnFailure(Func<Failure, Task<TReturn>> func)
        {
            if (this.IsFailure)
                _returnTask = func(Failure);

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
