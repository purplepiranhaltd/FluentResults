using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;

namespace PurplePiranha.FluentResults.Tests;

public class ResultsUnitTests
{
    public ResultsUnitTests()
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
        Assert.That(result.IsError, Is.False);
    }

    [Test]
    public void SuccessResultWithoutObject_DoesNotTriggerOnError()
    {
        var result = Result.SuccessResult();
        result.OnError(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    

    [Test]
    public void ErrorResultWithoutObject_DoesReturnError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        Assert.That(result.IsError, Is.True);
        Assert.That(result.Error, Is.EqualTo(Error.NullValue));
    }

    [Test]
    public void ErrorResultWithoutObject_DoesTriggerOnError()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnError(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void ErrorResultWithoutObject_DoesNotReturnSuccess()
    {
        var result = Result.ErrorResult(Error.NullValue);
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void ErrorResultWithoutObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.ErrorResult(Error.NullValue);
        result.OnSuccess(() =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    
}
