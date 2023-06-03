using FluentValidation.Results;
using Moq;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Results;

namespace PurplePiranha.FluentResults.Validation.Tests
{
    public class ResultWithValidationUnitTests
    {
        private ValidationResult _validationResult { get; }

        public ResultWithValidationUnitTests()
        {
            _validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Test", "Dummy Validation Error"), new ValidationFailure("Test2", "Dummy Validation Error 2") });
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SuccessResultWithoutObject_DoesNotReturnValidationFailure()
        {
            var result = ResultWithValidation.SuccessResult();
            Assert.That(result.IsValidationFailure, Is.False);
        }

        [Test]
        public void SuccessResultWithoutObject_DoesNotTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.SuccessResult();
            result.OnValidationFailure(v =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void SuccessResultWithoutObject_DoesReturnSuccess()
        {
            var result = ResultWithValidation.SuccessResult();
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public void SuccessResultWithoutObject_DoesTriggerOnSuccess()
        {
            var result = ResultWithValidation.SuccessResult();
            result.OnSuccess(() =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void SuccessResultWithoutObject_DoesNotReturnError()
        {
            var result = ResultWithValidation.SuccessResult();
            Assert.That(result.IsError, Is.False);
        }

        [Test]
        public void SuccessResultWithoutObject_DoesNotTriggerOnError()
        {
            var result = ResultWithValidation.SuccessResult();
            result.OnError(e =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }



        [Test]
        public void ErrorResultWithoutObject_DoesReturnError()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            Assert.That(result.IsError, Is.True);
            Assert.That(result.Error, Is.EqualTo(Error.NullValue));
        }

        [Test]
        public void ErrorResultWithoutObject_DoesTriggerOnError()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            result.OnError(e =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void ErrorResultWithoutObject_DoesNotReturnSuccess()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void ErrorResultWithoutObject_DoesNotTriggerOnSuccess()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            result.OnSuccess(() =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }


        [Test]
        public void ErrorResultWithoutObject_DoesNotReturnValidationFailure()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            Assert.That(result.IsValidationFailure, Is.False);
        }

        [Test]
        public void ErrorResultWithoutObject_DoesNotTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            result.OnValidationFailure(v =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesReturnValidationFailure()
        {
            var result = ResultWithValidation.ValidationFailureResult(_validationResult);
            Assert.That(result.IsValidationFailure, Is.True);
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.ValidationFailureResult(_validationResult);
            result.OnValidationFailure(v =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotReturnError()
        {
            var result = ResultWithValidation.ValidationFailureResult(_validationResult);
            Assert.That(result.IsError, Is.False);
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotTriggerOnError()
        {
            var result = ResultWithValidation.ValidationFailureResult(_validationResult);
            result.OnError(e =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotReturnSuccess()
        {
            var result = ResultWithValidation.ValidationFailureResult(_validationResult);
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotTriggerOnSuccess()
        {
            var result = ResultWithValidation.ErrorResult(Error.NullValue);
            result.OnSuccess(() =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void Result_Success_ConvertToResultT()
        {
            Result<int> result = Result.SuccessResult();
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.Value, Is.EqualTo(default(int)));
        }

        [Test]
        public void Result_Error_ConvertToResultT()
        {
            var testError = new Error("Test", "Testing");
            Result<int> result = Result.ErrorResult(testError);
            Assert.That(result.IsError, Is.EqualTo(true));
            Assert.That(result.Error, Is.EqualTo(testError));
        }

        [Test]
        public void Result_Success_CastToResultWithValidation()
        {
            ResultWithValidation result = Result.SuccessResult();
            Assert.That(result.IsSuccess, Is.EqualTo(true));
        }

        [Test]
        public void Result_Error_CastToResultWithValidation()
        {
            var testError = new Error("Test", "Testing");
            ResultWithValidation result = Result.ErrorResult(testError);
            Assert.That(result.IsError, Is.EqualTo(true));
            Assert.That(result.Error, Is.EqualTo(testError));
        }
    }
}