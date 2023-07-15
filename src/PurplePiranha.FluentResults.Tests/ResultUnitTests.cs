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
    public void SuccessResultWithoutObject_DoesNotReturnFailure()
    {
        var result = Result.SuccessResult();
        Assert.That(result.IsFailure, Is.False);
    }

    [Test]
    public void SuccessResultWithoutObject_DoesNotTriggerOnFailure()
    {
        var result = Result.SuccessResult();
        result.OnFailure(e =>
        {
            Assert.Fail();
        });
        Assert.Pass();
    }

    

    [Test]
    public void FailureResultWithoutObject_DoesReturnFailure()
    {
        var result = Result.FailureResult(new NullValueFailure());
        Assert.That(result.IsFailure, Is.True);
        Assert.That(result.Failure, Is.EqualTo(new NullValueFailure()));
    }

    [Test]
    public void FailureResultWithoutObject_DoesTriggerOnFailure()
    {
        var result = Result.FailureResult(new NullValueFailure());
        result.OnFailure(e =>
        {
            Assert.Pass();
        });
        Assert.Fail();
    }

    [Test]
    public void FailureResultWithoutObject_DoesNotReturnSuccess()
    {
        var result = Result.FailureResult(new NullValueFailure());
        Assert.That(result.IsSuccess, Is.False);
    }

    [Test]
    public void FailureResultWithoutObject_DoesNotTriggerOnSuccess()
    {
        var result = Result.FailureResult(new NullValueFailure());
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
    public void Result_Failure_ImplicitCastToResultT()
    {
        var testFailure = new NullValueFailure();
        Result<int> result = Result.FailureResult(testFailure);
        Assert.That(result.IsFailure, Is.EqualTo(true));
        Assert.That(result.Failure, Is.EqualTo(testFailure));
    }

    [Test]
    public void Result_FailureWithObject_ObjectIsAccessibleAndCorrectValue()
    {
        var testFailure = new WithDummyObjectFailure("Test", "Testing", new DummyObject(10, 2));
        Result<int> result = Result.FailureResult(testFailure);
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
