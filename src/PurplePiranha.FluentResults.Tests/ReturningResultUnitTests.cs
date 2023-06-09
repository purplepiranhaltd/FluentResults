﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.Errors;
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
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void ErrorResult_DoesReturnCorrectValue()
    {
        var v = Result
            .ErrorResult(new Error("Test", "Testing"))
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnError(e =>
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
            .OnError(async e =>
            {
                return await Task.FromResult(82);
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task ErrorResult_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .ErrorResult(new Error("Test", "Testing"))
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnError(async e =>
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
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void ErrorResultT_DoesReturnCorrectValue()
    {
        var v = Result
            .ErrorResult<int>(new Error("Test", "Testing"))
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnError(e =>
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
            .OnError(e =>
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
            .OnError(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task ErrorResultT_DoesReturnCorrectValue_Async()
    {
        var v = await Result
            .ErrorResult<int>(new Error("Test", "Testing"))
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnError(async e =>
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
            .OnError(async e =>
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
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void ErrorResult_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .ErrorResult(new Error("Test", "Testing"))
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnError(e =>
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
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void ErrorResultT_ActionResult_ReturnsCorrectAction()
    {
        var v = Result
            .ErrorResult<int>(new Error("Test", "Testing"))
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnError(e =>
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
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task ErrorResult_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .ErrorResult(new Error("Test", "Testing"))
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnError(async e =>
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
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task ErrorResultT_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await Result
            .ErrorResult<int>(new Error("Test", "Testing"))
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }
}
