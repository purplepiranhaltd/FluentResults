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
    public void SuccessResultWithObject_DoesNotReturnFailure()
    {
        var result = Result.SuccessResult(5);
        Assert.That(result.IsFailure, Is.False);
    }

    [Test]
    public void SuccessResultWithObject_DoesNotTriggerOnFailure()
    {
        var result = Result.SuccessResult(5);
        result.OnFailure(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    [Test]
    public void FailureResultWithObject_DoesReturnFailure()
    {
        var result = Result.FailureResult<int>(new NullValueFailure());
        Assert.That(result.IsFailure, Is.True);
    }

    [Test]
    public void FailureResultWithObject_DoesTriggerOnFailure()
    {
        var result = Result.FailureResult<int>(new NullValueFailure());
        result.OnFailure(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void FailureResultWithObject_DoesNotReturnSuccess()
    {
        var result = Result.FailureResult<int>(new NullValueFailure());
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void FailureResultWithObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.FailureResult<int>(new NullValueFailure());
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
    public void ResultT_Failure_ImplicitCastToResult()
    {
        var testFailure = new NullValueFailure();
        Result result = Result.FailureResult<int>(testFailure);
        Assert.That(result.IsFailure, Is.EqualTo(true));
        Assert.That(result.Failure, Is.EqualTo(testFailure));
    }

    [Test]
    public void ResultT_FailureWithObject_ObjectIsAccessibleAndCorrectValue()
    {
        var testFailure = new WithDummyObjectFailure("Test", "Testing", new DummyObject(10, 2));
        Result<int> result = Result.FailureResult<int>(testFailure);
        Assert.That(result.IsFailure, Is.EqualTo(true));
        Assert.That(result.Failure, Is.TypeOf(testFailure.GetType()));

        result.OnSuccess(v =>
        {
            Assert.Fail();
        })
        .OnFailure(f => {
            if (f is WithDummyObjectFailure dof)
            {
                var obj = dof.DummyObject;
                Assert.That(obj.X, Is.EqualTo(10));
                Assert.That(obj.Y, Is.EqualTo(2));
                Assert.Pass();
            }
        });

        Assert.Fail();
    }
}
