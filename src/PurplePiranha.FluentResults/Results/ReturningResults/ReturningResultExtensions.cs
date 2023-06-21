////using PurplePiranha.FluentResults.Errors;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace PurplePiranha.FluentResults.Results.ReturningResults
////{
////    public static class ReturningResultExtensions
////    {
////        public static async Task<IAsyncReturningResultWithOnSuccess<TReturn>> OnSuccess<TReturn>(this Task<IAsyncReturningResult<TReturn>> resultTask, Func<Task<TReturn>> func)
////        {
////            var result = await resultTask;

////            if(result.IsSuccess)
////                result.SetReturnValue(await func());

////            return (IAsyncReturningResultWithOnSuccess<TReturn>)result;
////        }

////        public static async Task<IAsyncReturningResultWithOnError<TReturn>> OnError<TReturn>(this Task<IAsyncReturningResult<TReturn>> resultTask, Func<Error, Task<TReturn>> func)
////        {
////            var result = await resultTask;

////#nullable disable
////            if (result.IsError) 
////                result.SetReturnValue(await(func(result.Error)));
////#nullable enable

////            return (IAsyncReturningResultWithOnError<TReturn>)result;
////        }
////    }
////}
