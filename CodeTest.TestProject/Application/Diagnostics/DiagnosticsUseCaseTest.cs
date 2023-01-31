using Application.Diagnostics;
using Application.Interface.API;
using AutoFixture.Xunit2;
using Domain;
using MediatR;
using Moq;
using FluentAssertions;

namespace CodeTest.TestProject.Application.Diagnostics;

public class DiagnosticsUseCaseTest
{
    private readonly IDiagnosticsUseCase _diagnosticsUseCase;
    private readonly Mock<IMediator> _mediator;

    public DiagnosticsUseCaseTest()
    {
        _mediator = new Mock<IMediator>();
        _diagnosticsUseCase = new DiagnosticsUseCase(_mediator.Object);
    }

    [Theory, AutoData]
    public void Should_Return_When_Log(DiagnosticsDTO diagnostics)
    {
        _mediator.Setup(x => x.Send(It.IsAny<LogDiagnosticsCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

        var result = _diagnosticsUseCase.Log(diagnostics);

        result.Result.Should().Be(Unit.Value);
    }
}