using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results.ReturningResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    public interface IAsyncReturningResult<TReturn> : IReturningResult<TReturn>
    {
    }

    public interface IAsyncReturningResult<TValue,TReturn> : IReturningResult<TValue,TReturn>
    {
    }

    public interface IAsyncReturningResultInitialState<TReturn> : IAsyncReturningResult<TReturn>
    {
        IAsyncReturningResultWithOnSuccess<TReturn> OnSuccess(Func<Task<TReturn>> func);
    }

    public interface IAsyncReturningResultInitialState<TValue, TReturn> : IAsyncReturningResult<TValue, TReturn>
    {
        IAsyncReturningResultWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithOnSuccess<TReturn> : IAsyncReturningResult<TReturn>
    {
        IAsyncReturningResultWithOnError<TReturn> OnError(Func<Error, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithOnSuccess<TValue, TReturn> : IAsyncReturningResult<TValue, TReturn>
    {
        IAsyncReturningResultWithOnError<TValue, TReturn> OnError(Func<Error, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithOnError<TReturn> : IAsyncReturningResult<TReturn>
    {
        Task<TReturn> ReturnAsync();
    }

    public interface IAsyncReturningResultWithOnError<TValue, TReturn> : IAsyncReturningResult<TValue, TReturn>
    {
        Task<TReturn> ReturnAsync();
    }
}
