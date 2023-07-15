using PurplePiranha.FluentResults.FailureTypes;
using PurplePiranha.FluentResults.Results;

namespace PurplePiranha.FluentResults.Tests;

public class ResultTUnitTests
{
    public ResultTUnitTests()
    {
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SuccessResultWithObject_DoesReturnSuccess()
    {
        var result = Result.SuccessResult(5);
        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public void SuccessResultWithObject_HasResultObject()
    {
        var result = Result.SuccessResult(5);
        Assert.That(result.Value, Is.EqualTo(5));
    }

    [Test]
    public void SuccessResultWithObject_DoesTriggerOnSuccess()
    {
        var result = Result.SuccessResult(5);
        result.OnSuccess(v =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void SuccessResultWithObject_DoesHaveCorrectResultAccessibleViaOnSuccess()
    {
        var result = Result.SuccessResult(5);
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
        var result = Result.SuccessResult(5);
        Assert.That(result.IsFailure, Is.False);
    }

    [Test]
    public void SuccessResultWithObject_DoesNotTriggerOnError()
    {
        var result = Result.SuccessResult(5);
        result.OnFailure(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void ErrorResultWithObject_DoesReturnError()
    {
        var result = Result.FailureResult<int>(FailureType.NullValue);
        Assert.That(result.IsFailure, Is.True);
    }

    [Test]
    public void ErrorResultWithObject_DoesTriggerOnError()
    {
        var result = Result.FailureResult<int>(FailureType.NullValue);
        result.OnFailure(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void ErrorResultWithObject_DoesNotReturnSuccess()
    {
        var result = Result.FailureResult<int>(FailureType.NullValue);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void ErrorResultWithObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.FailureResult<int>(FailureType.NullValue);
        result.OnSuccess(v =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void ResultT_Success_ImplicitCastToResult()
    {
        Result result = Result.SuccessResult(1);
        Assert.That(result.IsSuccess, Is.EqualTo(true));
    }

    [Test]
    public void ResultT_Error_ImplicitCastToResult()
    {
        var testError = new FailureType("Test", "Testing");
        Result result = Result.FailureResult<int>(testError);
        Assert.That(result.IsFailure, Is.EqualTo(true));
        Assert.That(result.FailureType, Is.EqualTo(testError));
    }
}
