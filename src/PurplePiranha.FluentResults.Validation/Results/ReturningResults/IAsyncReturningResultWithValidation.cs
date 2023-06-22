using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    public interface IAsyncReturningResultWithValidation<TReturn> : IReturningResultWithValidation<TReturn>
    {
    }

    public interface IAsyncReturningResultWithValidation<TValue, TReturn> : IReturningResultWithValidation<TValue, TReturn>
    {
    }

    public interface IAsyncReturningResultWithValidationInitialState<TReturn> : IAsyncReturningResultWithValidation<TReturn>
    {
        IAsyncReturningResultWithValidationWithOnSuccess<TReturn> OnSuccess(Func<Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationInitialState<TValue, TReturn> : IAsyncReturningResultWithValidation<TValue, TReturn>
    {
        IAsyncReturningResultWithValidationWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationWithOnSuccess<TReturn> : IAsyncReturningResultWithValidation<TReturn>
    {
        IAsyncReturningResultWithValidationWithOnValidationFailure<TReturn> OnValidationFailure(Func<ValidationResult, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationWithOnSuccess<TValue, TReturn> : IAsyncReturningResultWithValidation<TValue, TReturn>
    {
        IAsyncReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> OnValidationFailure(Func<ValidationResult, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationWithOnValidationFailure<TReturn> : IAsyncReturningResultWithValidation<TReturn>
    {
        IAsyncReturningResultWithValidationWithOnError<TReturn> OnError(Func<Error, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> : IAsyncReturningResultWithValidation<TValue, TReturn>
    {
        IAsyncReturningResultWithValidationWithOnError<TValue, TReturn> OnError(Func<Error, Task<TReturn>> func);
    }

    public interface IAsyncReturningResultWithValidationWithOnError<TReturn> : IAsyncReturningResultWithValidation<TReturn>
    {
        Task<TReturn> ReturnAsync();
    }

    public interface IAsyncReturningResultWithValidationWithOnError<TValue, TReturn> : IAsyncReturningResultWithValidation<TValue, TReturn>
    {
        Task<TReturn> ReturnAsync();
    }
}
