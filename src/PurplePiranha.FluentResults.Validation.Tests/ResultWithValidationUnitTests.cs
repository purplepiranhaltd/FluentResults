using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Results;

namespace PurplePiranha.FluentResults.Validation.Tests
{
    public class ResultWithValidationUnitTests
    {
        private IEnumerable<string> DummyValidationErrors { get; }

        public ResultWithValidationUnitTests()
        {
            var dummyValidationErrors = new List<string>();
            dummyValidationErrors.Add("Dummy Validation Error!");
            DummyValidationErrors = dummyValidationErrors;
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
            var result = ResultWithValidation.ValidationFailureResult(DummyValidationErrors);
            Assert.That(result.IsValidationFailure, Is.True);
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.ValidationFailureResult(DummyValidationErrors);
            result.OnValidationFailure(v =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotReturnError()
        {
            var result = ResultWithValidation.ValidationFailureResult(DummyValidationErrors);
            Assert.That(result.IsError, Is.False);
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotTriggerOnError()
        {
            var result = ResultWithValidation.ValidationFailureResult(DummyValidationErrors);
            result.OnError(e =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ValidationFailureResultWithoutObject_DoesNotReturnSuccess()
        {
            var result = ResultWithValidation.ValidationFailureResult(DummyValidationErrors);
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

    }
}