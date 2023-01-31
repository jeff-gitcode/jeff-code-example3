// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Rest;
using RestSharp;
using System;
using System.Threading;

public partial class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddScoped<IRestService, RestService>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        var restService = serviceProvider.GetService<IRestService>();

        // Create test data
        var calculator = new CalculatorDTO()
        {
            Start = 3,
            End = 2
        };

        // Add
        var endpoint = "/api/Calculator/Add";
        var response = restService.Post<CalculatorDTO, int>(endpoint, calculator).Result;
        Console.WriteLine($"Add({calculator.Start},{calculator.End})={response}");

        //Subtract
        endpoint = "/api/Calculator/Subtract";
        response = restService.Post<CalculatorDTO, int>(endpoint, calculator).Result;
        Console.WriteLine($"Add({calculator.Start},{calculator.End})={response}");

        //Multiply
        endpoint = "/api/Calculator/Multiply";
        response = restService.Post<CalculatorDTO, int>(endpoint, calculator).Result;
        Console.WriteLine($"Add({calculator.Start},{calculator.End})={response}");

        //Divide
        endpoint = "/api/Calculator/Divide";
        response = restService.Post<CalculatorDTO, int>(endpoint, calculator).Result;
        Console.WriteLine($"Add({calculator.Start},{calculator.End})={response}");

        Console.WriteLine("Press any key to exit.");
        
    }
}