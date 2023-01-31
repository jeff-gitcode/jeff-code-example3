using Application.Interface.API;
using Domain;
using MediatR;

namespace Application.Diagnostics;

public class DiagnosticsUseCase: IDiagnosticsUseCase
{
    private readonly IMediator _mediator;
    
    public DiagnosticsUseCase(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Unit> Log(DiagnosticsDTO diagnostics)
    {
        return await _mediator.Send(new LogDiagnosticsCommand(diagnostics));
    }
}