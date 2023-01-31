using Domain;

namespace Application.Interface.SPI
{
    public interface IDiagnosticsRepository
    {
        Task Add(DiagnosticsDTO diagnostics);
    }
}