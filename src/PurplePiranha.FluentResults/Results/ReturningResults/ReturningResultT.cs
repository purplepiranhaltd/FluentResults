////using PurplePiranha.FluentResults.Errors;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace PurplePiranha.FluentResults.Results.ReturningResults
////{
////    public class ReturningResult<TValue, TReturn> :
////        Result<TValue>,
////        IReturningResult<TValue, TReturn>,
////        IReturningResultWithOnSuccess<TValue, TReturn>,
////        IReturningResultWithOnError<TValue, TReturn>
////    {
////        private TReturn _returnValue;

////        TValue? IReturningResultWithValue<TValue, TReturn>.Value => base.Value;

////        bool IReturningResult<TReturn>.IsSuccess => base.IsSuccess;

////        bool IReturningResult<TReturn>.IsError => base.IsError;

////        Error? IReturningResult<TReturn>.Error => base.Error;

////        public ReturningResult(TValue? value, Error error, Dictionary<string, object>? customProperties = null) : base(value, error, customProperties)
////        {
////        }

////        public ReturningResult(Result<TValue> result) : base(result.Value, result.Error, result.CustomProperties)
////        {
////        }

////        void IReturningResult<TReturn>.SetReturnValue(TReturn returnValue)
////        {
////            _returnValue = returnValue;
////        }

////        TReturn IReturningResult<TReturn>.GetReturnValue()
////        {
////            if (_returnValue is null)
////                throw new ArgumentNullException(nameof(_returnValue));

////            return _returnValue;
////        }
////    }
////}
