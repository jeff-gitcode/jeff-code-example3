using System.Data;
using System.Data.SqlClient;
using Application.Interface.SPI;
using Domain;
using Infrastructure.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.DB;

public class DiagnosticsRepository : IDiagnosticsRepository
{
    private readonly IDateTimeService _dateTimeService;
    private readonly IOptions<ConfigurationSettings> _settings;
    private readonly ILogger<DiagnosticsRepository> _logger;

    public DiagnosticsRepository(IDateTimeService dateTimeService, IOptions<ConfigurationSettings> settings, ILogger<DiagnosticsRepository> logger)
    {
        _dateTimeService = dateTimeService;
        _settings = settings;
        _logger = logger;
    }

    public async Task Add(DiagnosticsDTO diagnostics)
    {
        try
        {
             _logger.LogInformation($"[Created] Receive Request from {diagnostics.Operation}");
            
            using SqlConnection connection = new(_settings.Value.ConnectionStrings.TestDBConnection);
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand("dbo.SP_DiagnosticsData", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Operation", diagnostics.Operation);
            command.Parameters.AddWithValue("@Results", diagnostics.Results);

            await command.ExecuteNonQueryAsync();

            Console.WriteLine("Data stored successfully");
            // var command = new SqlCommand("INSERT INTO Diagnostics (Id, Message, Result, Created) VALUES (@Id, @Message, @Result, @Created)", connection);

            // command.Parameters.AddWithValue("@Id", diagnostics.Id);
            // command.Parameters.AddWithValue("@Message", diagnostics.Message);
            // command.Parameters.AddWithValue("@Result", diagnostics.Result);
            // command.Parameters.AddWithValue("@Created", _dateTimeService.UtcNow);
            // await command.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding diagnostics");
        }
    }
}