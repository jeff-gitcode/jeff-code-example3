using Application.Interface.API;

using Ardalis.GuardClauses;

using Domain;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CalculatorController: ApiController
{
    private readonly ICalculatorUseCase _calculatorUseCase;

    public CalculatorController(ICalculatorUseCase calculatorUseCase)
    {
        Guard.Against.Null(calculatorUseCase, nameof(calculatorUseCase));

        _calculatorUseCase = calculatorUseCase;
    }

    [HttpPost("add")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult<int>> Add(CalculatorDTO calculatorDTO)
    {
        try
        {
            var result = await _calculatorUseCase.Add(calculatorDTO.Start, calculatorDTO.End);
            return Ok(result);
        }
        catch (System.Exception)
        {           
            throw;
        }
    }

    [HttpPost("subtract")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult<int>> Subtract(CalculatorDTO calculatorDTO)
    {
        try
        {
            var result = await _calculatorUseCase.Subtract(calculatorDTO.Start, calculatorDTO.End);
            return Ok(result);
        }
        catch (System.Exception)
        {           
            throw;
        }
    }

    [HttpPost("multiply")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Post))]
    public async Task<ActionResult<int>> Multiply(CalculatorDTO calculatorDTO)
    {
        try
        {
            var result = await _calculatorUseCase.Multiply(calculatorDTO.Start, calculatorDTO.End);
            return Ok(result);
        }
        catch (System.Exception)
        {           
            throw;
        }
    }

    [HttpPost("divide")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
        nameof(DefaultApiConventions.Post))]
   public async Task<ActionResult<int>> Divide(CalculatorDTO calculatorDTO)
    {
        try
        {
            var result = await _calculatorUseCase.Divide(calculatorDTO.Start, calculatorDTO.End);
            return Ok(result);
        }
        catch (System.Exception)
        {           
            throw;
        }
    }
}