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
        internal void SetReturnTask(Task<TReturn> task);
    }

    public interface IAsyncReturningResultInitialState<TReturn> : IAsyncReturningResult<TReturn>
    {
        IAsyncReturningResultWithOnSuccess<TReturn> OnSuccess(Func<Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithOnSuccess<TReturn> : IAsyncReturningResult<TReturn>
    {
        IAsyncReturningResultWithOnError<TReturn> OnError(Func<Error, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithOnError<TReturn> : IAsyncReturningResult<TReturn>
    {
        Task<TReturn> ReturnAsync();
    }
}
