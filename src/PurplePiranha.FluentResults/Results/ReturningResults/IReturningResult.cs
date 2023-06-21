using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Results.ReturningResults
{
    #region Base
    public interface IReturningResult<TReturn>
    {
        bool IsSuccess { get; }
        bool IsError { get; }
        Error? Error { get; }
    }
    #endregion
    #region Without value
    public interface IReturningResultInitialState<TReturn> : IReturningResult<TReturn>
    {
        IReturningResultWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func);
    }

    public interface IReturningResultWithOnSuccess<TReturn> : IReturningResult<TReturn>
    {
        IReturningResultWithOnError<TReturn> OnError(Func<Error, TReturn> func);
    }

    public interface IReturningResultWithOnError<TReturn> : IReturningResult<TReturn>
    {
        TReturn Return();
    }
    #endregion
    #region With value

    public interface IReturningResult<TValue, TReturn> : IReturningResult<TReturn>
    {
        TValue? Value { get; }
    }

    public interface IReturningResultInitialState<TValue, TReturn> : IReturningResult<TValue, TReturn>
    {
        IReturningResultWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, TReturn> func);
    }

    public interface IReturningResultWithOnSuccess<TValue, TReturn> : IReturningResult<TValue, TReturn>
    {
        IReturningResultWithOnError<TValue, TReturn> OnError(Func<Error, TReturn> func);
    }

    public interface IReturningResultWithOnError<TValue, TReturn> : IReturningResult<TValue, TReturn>
    {
        TReturn Return();
    }
    #endregion
}
