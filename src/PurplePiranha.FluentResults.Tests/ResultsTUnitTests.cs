using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;

namespace PurplePiranha.FluentResults.Tests;

public class ResultsTUnitTests
{
    public ResultsTUnitTests()
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
        Assert.That(result.IsError, Is.False);
    }

    [Test]
    public void SuccessResultWithObject_DoesNotTriggerOnError()
    {
        var result = Result.SuccessResult(5);
        result.OnError(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void ErrorResultWithObject_DoesReturnError()
    {
        var result = Result.ErrorResult<int>(Error.NullValue);
        Assert.That(result.IsError, Is.True);
    }

    [Test]
    public void ErrorResultWithObject_DoesTriggerOnError()
    {
        var result = Result.ErrorResult<int>(Error.NullValue);
        result.OnError(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void ErrorResultWithObject_DoesNotReturnSuccess()
    {
        var result = Result.ErrorResult<int>(Error.NullValue);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void ErrorResultWithObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.ErrorResult<int>(Error.NullValue);
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
        var testError = new Error("Test", "Testing");
        Result result = Result.ErrorResult<int>(testError);
        Assert.That(result.IsError, Is.EqualTo(true));
        Assert.That(result.Error, Is.EqualTo(testError));
    }
}
