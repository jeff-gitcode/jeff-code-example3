using Application.Behaviours;
using Application.Interface.API;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.Diagnostics;
using Application.Calculator;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDiagnosticsUseCase, DiagnosticsUseCase>();
            services.AddScoped<ICalculatorUseCase, CalculatorUseCase>();

            // it's slow
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Register Mapster, faster
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<MapsterMapper.IMapper, ServiceMapper>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));

            return services;
        }
    }
}