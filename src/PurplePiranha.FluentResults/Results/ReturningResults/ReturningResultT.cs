using PurplePiranha.FluentResults.FailureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    public class ReturningResult<TValue, TReturn> :
        Result<TValue>,
        IReturningResultInitialState<TValue, TReturn>,
        IReturningResultWithOnSuccess<TValue, TReturn>,
        IReturningResultWithOnError<TValue, TReturn>
    {
        private TReturn _returnValue;

        public ReturningResult(TValue? value, FailureType error, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
        {
        }

        public ReturningResult(Result<TValue> result) : base(result.Value, result.FailureType, result.CustomProperties)
        {
        }

        public IReturningResultWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, TReturn> func)
        {
#nullable disable
            if (IsSuccess)
                _returnValue = func(Value);
#nullable enable

            return this;
        }

        public IReturningResultWithOnError<TValue, TReturn> OnError(Func<FailureType, TReturn> func)
        {
            if (IsFailure)
                _returnValue = func(FailureType);

            return this;
        }

        public TReturn Return()
        {
            return _returnValue;
        }
    }
}
