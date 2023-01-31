using Domain;
using MediatR;

namespace Application.Interface.API
{

    public interface IDiagnosticsUseCase
    {
        Task<Unit> Log(DiagnosticsDTO diagnostics);
    }
}