using Application.Interface.SPI;
using Infrastructure.Config;
using Infrastructure.DB;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<ConfigurationSettings>(configuration);
            var serviceProvider = services.BuildServiceProvider();
            var opt = serviceProvider.GetRequiredService<IOptions<ConfigurationSettings>>().Value;

            // use ef core
            services.AddDbContext<DemoDBContext>(options =>
            {
                options.UseSqlServer(
                    opt.ConnectionStrings.TestDBConnection,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                    });
            });                    
            
            services.AddScoped<IDbContext>(provider => provider.GetRequiredService<DemoDBContext>());

            // memory cache
            services.AddMemoryCache();


            services.AddSingleton<IDateTimeService, DateTimeService>();

            services.AddScoped<ISimpleCalculator, SimpleCalculatorService>();

            Console.WriteLine($"Using EF Core? {opt.ConnectionStrings.EFCore}");

            if (opt.ConnectionStrings.EFCore == "True")
            {
                Console.WriteLine("Using EF Core");
                services.AddScoped<IDiagnosticsRepository, DiagnosticsEFRepository>();
            }
            else
            {
                Console.WriteLine("Using SQL Server Stored Procedure");
                services.AddScoped<IDiagnosticsRepository, DiagnosticsRepository>();
            }
            services.AddScoped<IDiagnosticsRepository, DiagnosticsEFRepository>();

            // adding health check service.
            services.AddHealthChecks()
                   .AddDbContextCheck<DemoDBContext>();

            return services;
        }
    }
}