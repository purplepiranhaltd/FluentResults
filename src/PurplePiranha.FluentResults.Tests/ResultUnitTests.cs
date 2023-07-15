using PurplePiranha.FluentResults.FailureTypes;
using PurplePiranha.FluentResults.Results;

namespace PurplePiranha.FluentResults.Tests;

public class ResultUnitTests
{
    public ResultUnitTests()
    {
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SuccessResultWithoutObject_DoesReturnSuccess()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public void SuccessResultWithoutObject_DoesTriggerOnSuccess()
    {
        var result = Result.SuccessResult();
        result.OnSuccess(() =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void SuccessResultWithoutObject_DoesNotReturnError()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsFailure, Is.False);
    }

    [Test]
    public void SuccessResultWithoutObject_DoesNotTriggerOnError()
    {
        var result = Result.SuccessResult();
        result.OnFailure(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    

    [Test]
    public void ErrorResultWithoutObject_DoesReturnError()
    {
        var result = Result.FailureResult(FailureType.NullValue);
        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.FailureType, Is.EqualTo(FailureType.NullValue));
    }

    [Test]
    public void ErrorResultWithoutObject_DoesTriggerOnError()
    {
        var result = Result.FailureResult(FailureType.NullValue);
        result.OnFailure(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void ErrorResultWithoutObject_DoesNotReturnSuccess()
    {
        var result = Result.FailureResult(FailureType.NullValue);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void ErrorResultWithoutObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.FailureResult(FailureType.NullValue);
        result.OnSuccess(() =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void Result_Success_ImplicitCastToResultT()
    {
        Result<int> result = Result.SuccessResult();
        Assert.That(result.IsSuccess, Is.EqualTo(true));
        Assert.That(result.Value, Is.EqualTo(default(int)));
    }

    [Test]
    public void Result_Error_ImplicitCastToResultT()
    {
        var testError = new FailureType("Test", "Testing");
        Result<int> result = Result.FailureResult(testError);
        Assert.That(result.IsFailure, Is.EqualTo(true));
        Assert.That(result.FailureType, Is.EqualTo(testError));
    }
}
