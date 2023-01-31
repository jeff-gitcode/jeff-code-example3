using Application.Interface.SPI;
using Domain;
using MediatR;

namespace Application.Diagnostics;

public record LogDiagnosticsCommand(DiagnosticsDTO diagnostics) : IRequest<Unit>;

public class LogDiagnosticsCommandHandler : IRequestHandler<LogDiagnosticsCommand, Unit>
{
    private readonly IDiagnosticsRepository _diagnosticsRepository;

    public LogDiagnosticsCommandHandler(IDiagnosticsRepository diagnosticsRepository) => _diagnosticsRepository = diagnosticsRepository;

    public async Task<Unit> Handle(LogDiagnosticsCommand request, CancellationToken cancellationToken)
    {
        await _diagnosticsRepository.Add(request.diagnostics);

        return Unit.Value;
    }
}
