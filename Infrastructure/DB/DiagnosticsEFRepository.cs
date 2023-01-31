using Application.Interface.SPI;
using Domain;
using Infrastructure.DB;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DB;

public class DiagnosticsEFRepository : IDiagnosticsRepository
{

    private readonly IDbContext _context;
    private readonly ILogger<DiagnosticsEFRepository> _logger;

    public DiagnosticsEFRepository(IDbContext context, ILogger<DiagnosticsEFRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Add(DiagnosticsDTO diagnostics)
    {
        try
        {
            _logger.LogInformation($"[Created] Receive Request from {diagnostics.Operation}");
            
            _context.Diagnostics.Add(diagnostics);

            int result = await _context.SaveChangesAsync();
            Console.WriteLine("Data stored successfully");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding diagnostics");
        }
    }
}