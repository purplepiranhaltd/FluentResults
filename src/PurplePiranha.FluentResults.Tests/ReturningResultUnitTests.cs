using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.FailureTypes;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Results.ReturningResults;
using PurplePiranha.FluentResults.Results.ReturningResults.ActionResults;

namespace PurplePiranha.FluentResults.Tests;

public class ReturningResultUnitTests
{
    private AcceptedResult _acceptedResult;
    private BadRequestResult _badRequestResult;

    public ReturningResultUnitTests()
    {
        _acceptedResult = new AcceptedResult();
        _badRequestResult = new BadRequestResult();
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SuccessResult_DoesReturnCorrectValue()
    {
        var v = Result
            .SuccessResult()
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnFailure(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void FailureResult_DoesReturnCorrectValue()
    {
        var v = Result
            .FailureResult(new NullValueFailure())
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnFailure(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(82));
    }

    [Test]
    public async Task SuccessResult_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .SuccessResult()
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnFailure(async e =>
            {
                return await Task.FromResult(82);
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task FailureResult_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .FailureResult(new NullValueFailure())
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnFailure(async e =>
            {
                return await Task.FromResult(82);
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(82));
    }

    [Test]
    public void SuccessResultT_DoesReturnCorrectValue()
    {
        var v = Result
            .SuccessResult(500)
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnFailure(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void FailureResultT_DoesReturnCorrectValue()
    {
        var v = Result
            .FailureResult<int>(new NullValueFailure())
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnFailure(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(82));
    }

    [Test]
    public void SuccessResultT_HasCorrectResultValue()
    {
        var v = Result
            .SuccessResult(500)
            .Returning<int>()
            .OnSuccess(v =>
            {
                return v;
            })
            .OnFailure(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(500));
    }

    [Test]
    public async Task SuccessResultT_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .SuccessResult(500)
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnFailure(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task FailureResultT_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .FailureResult<int>(new NullValueFailure())
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnFailure(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(82));
    }

    [Test]
    public async Task SuccessResultT_HasCorrectResultValue_Async()
    {
        var v = await Result
            .SuccessResult(500)
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return v;
            })
            .OnFailure(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(500));
    }

    [Test]
    public void SuccessResult_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .SuccessResult()
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnFailure(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void FailureResult_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .FailureResult(new NullValueFailure())
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnFailure(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }

    [Test]
    public void SuccessResultT_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .SuccessResult(500)
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnFailure(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void FailureResultT_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .FailureResult<int>(new NullValueFailure())
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnFailure(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }

    [Test]
    public async Task SuccessResult_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .SuccessResult()
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnFailure(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task FailureResult_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .FailureResult(new NullValueFailure())
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnFailure(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }

    [Test]
    public async Task SuccessResultT_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .SuccessResult(500)
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnFailure(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task FailureResultT_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .FailureResult<int>(new NullValueFailure())
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnFailure(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }
}
