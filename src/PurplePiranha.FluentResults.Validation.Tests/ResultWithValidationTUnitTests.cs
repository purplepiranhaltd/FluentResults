using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Validation.Results;

namespace PurplePiranha.FluentResults.Validation.Tests
{
    public class ResultWithValidationTUnitTests
    {
        private IEnumerable<string> DummyValidationErrors { get; }

        public ResultWithValidationTUnitTests()
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
        public void SuccessResultWithObject_DoesNotReturnValidationFailure()
        {
            var result = ResultWithValidation.SuccessResult(5);
            Assert.That(result.IsValidationFailure, Is.False);
        }

        [Test]
        public void SuccessResultWithObject_DoesNotTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.SuccessResult(5);
            result.OnValidationFailure(v =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ErrorResultWithObject_DoesNotReturnValidationFailure()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            Assert.That(result.IsValidationFailure, Is.False);
        }

        [Test]
        public void ErrorResultWithObject_DoesNotTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            result.OnValidationFailure(v =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ValidationFailureResultWithObject_DoesReturnValidationFailure()
        {
            var result = ResultWithValidation.ValidationFailureResult<int>(DummyValidationErrors);
            Assert.That(result.IsValidationFailure, Is.True);
        }

        [Test]
        public void ValidationFailureResultWithObject_DoesTriggerOnValidationFailure()
        {
            var result = ResultWithValidation.ValidationFailureResult<int>(DummyValidationErrors);
            result.OnValidationFailure(v =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void ValidationFailureResultWithObject_DoesNotReturnError()
        {
            var result = ResultWithValidation.ValidationFailureResult<int>(DummyValidationErrors);
            Assert.That(result.IsError, Is.False);
        }

        [Test]
        public void ValidationFailureResultWithObject_DoesNotTriggerOnError()
        {
            var result = ResultWithValidation.ValidationFailureResult<int>(DummyValidationErrors);
            result.OnError(e =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ValidationFailureResultWithObject_DoesNotReturnSuccess()
        {
            var result = ResultWithValidation.ValidationFailureResult<int>(DummyValidationErrors);
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void SuccessResultWithObject_DoesReturnSuccess()
        {
            var result = ResultWithValidation.SuccessResult(5);
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public void SuccessResultWithObject_HasResultObject()
        {
            var result = ResultWithValidation.SuccessResult(5);
            Assert.That(result.Value, Is.EqualTo(5));
        }

        [Test]
        public void SuccessResultWithObject_DoesTriggerOnSuccess()
        {
            var result = ResultWithValidation.SuccessResult(5);
            result.OnSuccess(() =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void SuccessResultWithObject_DoesHaveCorrectResultAccessibleViaOnSuccess()
        {
            var result = ResultWithValidation.SuccessResult(5);
            result.OnSuccess(r =>
            {
                Assert.That(r, Is.EqualTo(5));
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void SuccessResultWithObject_DoesNotReturnError()
        {
            var result = ResultWithValidation.SuccessResult(5);
            Assert.That(result.IsError, Is.False);
        }

        [Test]
        public void SuccessResultWithObject_DoesNotTriggerOnError()
        {
            var result = ResultWithValidation.SuccessResult(5);
            result.OnError(e =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }

        [Test]
        public void ErrorResultWithObject_DoesReturnError()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            Assert.That(result.IsError, Is.True);
        }

        [Test]
        public void ErrorResultWithObject_DoesTriggerOnError()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            result.OnError(e =>
            {
                Assert.Pass();
            });
            Assert.Fail();
        }

        [Test]
        public void ErrorResultWithObject_DoesNotReturnSuccess()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void ErrorResultWithObject_DoesNotTriggerOnSuccess()
        {
            var result = ResultWithValidation.ErrorResult<int>(Error.NullValue);
            result.OnSuccess(() =>
            {
                Assert.Fail();
            });
            Assert.Pass();
        }
    }
}