using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;

namespace PurplePiranha.FluentResults.Tests;

public class ResultsUnitTests
{
    private IEnumerable<string> DummyValidationErrors { get; }

    public ResultsUnitTests()
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
    public void Test_SuccessResultWithoutObject_DoesReturnSuccess()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public void Test_SuccessResultWithoutObject_DoesTriggerOnSuccess()
    {
        var result = Result.SuccessResult();
        result.OnSuccess(() =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void Test_SuccessResultWithoutObject_DoesNotReturnError()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsError, Is.False);
    }

    [Test]
    public void Test_SuccessResultWithoutObject_DoesNotTriggerOnError()
    {
        var result = Result.SuccessResult();
        result.OnError(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_SuccessResultWithoutObject_DoesNotReturnValidationFailure()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsValidationFailure, Is.False);
    }

    [Test]
    public void Test_SuccessResultWithoutObject_DoesNotTriggerOnValidationFailure()
    {
        var result = Result.SuccessResult();
        result.OnValidationFailure(v =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesReturnError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        Assert.That(result.IsError, Is.True);
        Assert.That(result.Error, Is.EqualTo(Error.NullValue));
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesTriggerOnError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnError(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesNotReturnSuccess()
    {
        var result = Result.ErrorResult(Error.NullValue);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnSuccess(() =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesNotReturnValidationFailure()
    {
        var result = Result.ErrorResult(Error.NullValue);
        Assert.That(result.IsValidationFailure, Is.False);
    }

    [Test]
    public void Test_ErrorResultWithoutObject_DoesNotTriggerOnValidationFailure()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnValidationFailure(v =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesReturnValidationFailure()
    {
        var result = Result.ValidationFailureResult(DummyValidationErrors);
        Assert.That(result.IsValidationFailure, Is.True);
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesTriggerOnValidationFailure()
    {
        var result = Result.ValidationFailureResult(DummyValidationErrors);
        result.OnValidationFailure(v =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesNotReturnError()
    {
        var result = Result.ValidationFailureResult(DummyValidationErrors);
        Assert.That(result.IsError, Is.False);
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesNotTriggerOnError()
    {
        var result = Result.ValidationFailureResult(DummyValidationErrors);
        result.OnError(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesNotReturnSuccess()
    {
        var result = Result.ValidationFailureResult(DummyValidationErrors);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void Test_ValidationFailureResultWithoutObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnSuccess(() =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Test_SuccessResultToTypedResult_ReturnsCorrectTypedResult()
    {
        var result = Result.SuccessResult();
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult, Is.TypeOf<Result<int>>());
    }

    [Test]
    public void Test_SuccessResultToTypedResult_ReturnsDefaultValue()
    {
        var result = Result.SuccessResult();
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.Value, Is.EqualTo(default(int)));
    }

    [Test]
    public void Test_SuccessResultToTypedResult_IsSuccess()
    {
        var result = Result.SuccessResult();
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.IsSuccess, Is.EqualTo(true));
    }

    [Test]
    public void Test_ErrorResultToTypedResult_ReturnsCorrectTypedResult()
    {
        var result = Result.ErrorResult(Error.NullValue);
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult, Is.TypeOf<Result<int>>());
    }

    [Test]
    public void Test_SuccessResultToTypedResult_IsError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.IsError, Is.EqualTo(true));
    }

    [Test]
    public void Test_ErrorResultToTypedResult_ReturnsCorrectError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.Error, Is.EqualTo(Error.NullValue));
    }

    [Test]
    public void Test_ValidationFailureResultToTypedResult_ReturnsCorrectTypedResult()
    {
        var result = Result.ValidationFailureResult(new string[] { "Test" }.ToList());
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult, Is.TypeOf<Result<int>>());
    }

    [Test]
    public void Test_ValidationFailureResultToTypedResult_IsValidationFailure()
    {
        var result = Result.ValidationFailureResult(new string[] { "Test" }.ToList());
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.IsValidationFailure, Is.EqualTo(true));
    }

    [Test]
    public void Test_ValidationFailureResultToTypedResult_ReturnsValidationFailures()
    {
        var result = Result.ValidationFailureResult(new string[] { "Test1", "Test2", "Test3" }.ToList());
        var typedResult = result.ToTypedResult<int>();
        Assert.That(typedResult.ValidationErrors.Count, Is.EqualTo(3));
    }
}
