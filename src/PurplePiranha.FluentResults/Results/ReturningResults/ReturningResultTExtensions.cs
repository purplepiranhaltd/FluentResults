////using PurplePiranha.FluentResults.Errors;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace PurplePiranha.FluentResults.Results.ReturningResults
////{
////    public static class ReturningResultTExtensions
////    {
////        ////public static Task<IReturningResult<TValue, TReturn>> Returning<TValue, TReturn>(this Result<TValue> result)
////        ////{
////        ////    return Task.FromResult((IReturningResult<TValue, TReturn>)new ReturningResult<TReturn, TValue>(result));
////        ////}

////        public static async Task<IReturningResultWithOnSuccess<TValue, TReturn>> OnSuccess<TValue, TReturn>(this Task<IReturningResult<TValue, TReturn>> resultTask, Func<TValue, Task<TReturn>> func)
////        {
////            var result = await resultTask;

////#nullable disable
////            if (result.IsSuccess)
////                result.SetReturnValue(await func(result.Value));
////#nullable enable

////            return (IReturningResultWithOnSuccess<TValue, TReturn>)result;
////        }

////        public static async Task<IReturningResultWithOnError<TValue, TReturn>> OnError<TValue, TReturn>(this Task<IReturningResultWithOnSuccess<TValue, TReturn>> resultTask, Func<Error, Task<TReturn>> func)
////        {
////            var result = await resultTask;

////#nullable disable
////            if (result.IsError)
////                result.SetReturnValue(await func(result.Error));
////#nullable enable

////            return (IReturningResultWithOnError<TValue, TReturn>)result;
////        }

////        public static async Task<TReturn> Return<TValue, TReturn>(this Task<IReturningResultWithOnError<TValue, TReturn>> resultTask)
////        {
////            var result = await resultTask;
////            return result.GetReturnValue();
////        }
////    }
////}
