using Application.Diagnostics;
using Application.Interface.API;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace CodeTest.TestProject.Application.Diagnostics;


public class LogDiagnosticsCommandTest
{
    private readonly Mock<ILogger<LogDiagnosticsCommand>> _loggerMock;
    private readonly Mock<IDiagnosticsUseCase> _diagnosticsUseCaseMock;
    private readonly Mock<IMediator> _mediatorMock;

    public LogDiagnosticsCommandTest()
    {
        _loggerMock = new Mock<ILogger<LogDiagnosticsCommand>>();
        _diagnosticsUseCaseMock = new Mock<IDiagnosticsUseCase>();
        _mediatorMock = new Mock<IMediator>();
    }

    [Fact]
    public async Task Handle_DiagnosticsDTO_ShouldReturnUnit()
    {
        var diagnosticsDTO = new DiagnosticsDTO
        {
            Operation = "Test Message",
            Results = 1
        };

        var logDiagnosticsCommand = new LogDiagnosticsCommand(diagnosticsDTO);

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<LogDiagnosticsCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        var result = await _mediatorMock.Object.Send(logDiagnosticsCommand);

        Assert.Equal(Unit.Value, result);
    }
}
