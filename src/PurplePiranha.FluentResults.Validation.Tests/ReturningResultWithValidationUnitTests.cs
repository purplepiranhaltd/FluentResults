using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PurplePiranha.FluentResults.Errors;
using PurplePiranha.FluentResults.Results;
using PurplePiranha.FluentResults.Results.ReturningResults;
using PurplePiranha.FluentResults.Results.ReturningResults.ActionResults;
using PurplePiranha.FluentResults.Validation.Results;
using PurplePiranha.FluentResults.Validation.Results.ReturningResults.ActionResults;

namespace PurplePiranha.FluentResults.Validation.Tests;

public class ReturningResultWithValidationUnitTests
{
    private ValidationResult _validationResult { get; }
    private AcceptedResult _acceptedResult;
    private BadRequestResult _badRequestResult;
    private ConflictResult _conflictResult;

    public ReturningResultWithValidationUnitTests()
    {
        _validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Test", "Dummy Validation Error"), new ValidationFailure("Test2", "Dummy Validation Error 2") });
        _acceptedResult = new AcceptedResult();
        _badRequestResult = new BadRequestResult();
        _conflictResult = new ConflictResult();
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SuccessResult_DoesReturnCorrectValue()
    {
        var v = ResultWithValidation
            .SuccessResult()
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
            })
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void ValidationFailureResult_DoesReturnCorrectValue()
    {
        var v = ResultWithValidation
            .ValidationFailureResult(_validationResult)
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
            })
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(42));
    }

    [Test]
    public void ErrorResult_DoesReturnCorrectValue()
    {
        var v = ResultWithValidation
            .ErrorResult(new Error("Test", "Testing"))
            .Returning<int>()
            .OnSuccess(() =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
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
        var v = await ResultWithValidation
            .SuccessResult()
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnValidationFailure(async vf => {
                return await Task.FromResult(42);
            })
            .OnError(async e =>
            {
                return await Task.FromResult(82);
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task ValidationFailureResult_DoesReturnCorrectValue_Async()
    {
        var v = await ResultWithValidation
            .ValidationFailureResult(_validationResult)
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnValidationFailure(async vf => {
                return await Task.FromResult(42);
            })
            .OnError(async e =>
            {
                return await Task.FromResult(82);
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(42));
    }

    [Test]
    public async Task ErrorResult_DoesReturnCorrectValue_Async()
    {
        var v = await ResultWithValidation
            .ErrorResult(new Error("Test", "Testing"))
            .AsyncReturning<int>()
            .OnSuccess(async () =>
            {
                return await Task.FromResult(67);
            })
            .OnValidationFailure(async vf => {
                return await Task.FromResult(42);
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
        var v = ResultWithValidation
            .SuccessResult(500)
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
            })
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public void ValidationFailureResultT_DoesReturnCorrectValue()
    {
        var v = ResultWithValidation
            .ValidationFailureResult<int>(_validationResult)
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
            })
            .OnError(e =>
            {
                return 82;
            })
            .Return();

        Assert.That(v, Is.EqualTo(42));
    }

    [Test]
    public void ErrorResultT_DoesReturnCorrectValue()
    {
        var v = ResultWithValidation
            .ErrorResult<int>(new Error("Test", "Testing"))
            .Returning<int>()
            .OnSuccess(v =>
            {
                return 67;
            })
            .OnValidationFailure(vf => {
                return 42;
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
        var v = ResultWithValidation
            .SuccessResult(500)
            .Returning<int>()
            .OnSuccess(v =>
            {
                return v;
            })
            .OnValidationFailure(vf => {
                return 42;
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
        var v = await ResultWithValidation
            .SuccessResult(500)
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnValidationFailure(async vf => {
                return 42;
            })
            .OnError(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(67));
    }

    [Test]
    public async Task ValidationFailureResultT_DoesReturnCorrectValue_Async()
    {
        var v = await ResultWithValidation
            .ValidationFailureResult<int>(_validationResult)
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnValidationFailure(async vf => {
                return 42;
            })
            .OnError(async e =>
            {
                return 82;
            })
            .ReturnAsync();

        Assert.That(v, Is.EqualTo(42));
    }

    [Test]
    public async Task ErrorResultT_DoesReturnCorrectValue_Async()
    {
        var v = await ResultWithValidation
            .ErrorResult<int>(new Error("Test", "Testing"))
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return 67;
            })
            .OnValidationFailure(async vf => {
                return 42;
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
        var v = await ResultWithValidation
            .SuccessResult(500)
            .AsyncReturning<int>()
            .OnSuccess(async v =>
            {
                return v;
            })
            .OnValidationFailure(async vf => {
                return 42;
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
        var v = ResultWithValidation
            .SuccessResult()
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
            })
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void ValidationFailureResult_ActionResult_ReturnsCorrectAction()
    {
        var v = ResultWithValidation
            .ValidationFailureResult(_validationResult)
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
            })
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_conflictResult));
    }

    [Test]
    public void ErrorResult_ActionResult_ReturnsCorrectAction()
    {
        var v = ResultWithValidation
            .ErrorResult(new Error("Test", "Testing"))
            .ReturningActionResult()
            .OnSuccess(() =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
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
        var v = ResultWithValidation
            .SuccessResult(500)
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
            })
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public void ValidationFailureResultT_ActionResult_ReturnsCorrectAction()
    {
        var v = ResultWithValidation
            .ValidationFailureResult<int>(_validationResult)
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
            })
            .OnError(e =>
            {
                return _badRequestResult;
            })
            .Return();

        Assert.That(v, Is.SameAs(_conflictResult));
    }

    [Test]
    public void ErrorResultT_ActionResult_ReturnsCorrectAction()
    {
        var v = ResultWithValidation
            .ErrorResult<int>(new Error("Test", "Testing"))
            .ReturningActionResult()
            .OnSuccess(v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(vf => {
                return _conflictResult;
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
        var v = await ResultWithValidation
            .SuccessResult()
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task ValidationFailureResult_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await ResultWithValidation
            .ValidationFailureResult(_validationResult)
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_conflictResult));
    }

    [Test]
    public async Task ErrorResult_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await ResultWithValidation
            .ErrorResult(new Error("Test", "Testing"))
            .AsyncReturningActionResult()
            .OnSuccess(async () =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
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
        var v = await ResultWithValidation
            .SuccessResult(500)
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_acceptedResult));
    }

    [Test]
    public async Task ValidationFailureResultT_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await ResultWithValidation
            .ValidationFailureResult<int>(_validationResult)
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_conflictResult));
    }

    [Test]
    public async Task ErrorResultT_ActionResult_ReturnsCorrectAction_Async()
    {
        var v = await ResultWithValidation
            .ErrorResult<int>(new Error("Test", "Testing"))
            .AsyncReturningActionResult()
            .OnSuccess(async v =>
            {
                return _acceptedResult;
            })
            .OnValidationFailure(async vf => {
                return _conflictResult;
            })
            .OnError(async e =>
            {
                return _badRequestResult;
            })
            .ReturnAsync();

        Assert.That(v, Is.SameAs(_badRequestResult));
    }
}
