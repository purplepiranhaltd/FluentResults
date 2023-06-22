using FluentValidation.Results;
using PurplePiranha.FluentResults.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurplePiranha.FluentResults.Validation.Results.ReturningResults
{
    #region Base
    public interface IReturningResultWithValidation<TReturn>
    {
        bool IsSuccess { get; }
        bool IsError { get; }
        Error? Error { get; }
    }
    #endregion
    #region Without value
    public interface IReturningResultWithValidationInitialState<TReturn> : IReturningResultWithValidation<TReturn>
    {
        IReturningResultWithValidationWithOnSuccess<TReturn> OnSuccess(Func<TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnSuccess<TReturn> : IReturningResultWithValidation<TReturn>
    {
        IReturningResultWithValidationWithOnValidationFailure<TReturn> OnValidationFailure(Func<ValidationResult, TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnValidationFailure<TReturn> : IReturningResultWithValidation<TReturn>
    {
        IReturningResultWithValidationWithOnError<TReturn> OnError(Func<Error, TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnError<TReturn> : IReturningResultWithValidation<TReturn>
    {
        TReturn Return();
    }
    #endregion
    #region With value

    public interface IReturningResultWithValidation<TValue, TReturn> : IReturningResultWithValidation<TReturn>
    {
        TValue? Value { get; }
    }

    public interface IReturningResultWithValidationInitialState<TValue, TReturn> : IReturningResultWithValidation<TValue, TReturn>
    {
        IReturningResultWithValidationWithOnSuccess<TValue, TReturn> OnSuccess(Func<TValue, TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnSuccess<TValue, TReturn> : IReturningResultWithValidation<TValue, TReturn>
    {
        IReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> OnValidationFailure(Func<ValidationResult, TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnValidationFailure<TValue, TReturn> : IReturningResultWithValidation<TValue, TReturn>
    {
        IReturningResultWithValidationWithOnError<TValue, TReturn> OnError(Func<Error, TReturn> func);
    }

    public interface IReturningResultWithValidationWithOnError<TValue, TReturn> : IReturningResultWithValidation<TValue, TReturn>
    {
        TReturn Return();
    }
    #endregion
}
