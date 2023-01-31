using Application.Interface.API;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace CodeTest.TestProject.WebApi;

public class CalculatorControllerTest
{
    private readonly Mock<ICalculatorUseCase> _calculatorUseCase;
    private readonly CalculatorController _calculatorController;

    public CalculatorControllerTest()
    {
        _calculatorUseCase = new Mock<ICalculatorUseCase>();
        _calculatorController = new CalculatorController(_calculatorUseCase.Object);
    }

    [Theory, AutoData]
    public async Task Add_WithValidInput_Should_ReturnsOk(int start, int amount)
    {
        _calculatorUseCase.Setup(x => x.Add(start, amount)).ReturnsAsync(start + amount);

        var response = await _calculatorController.Add(new Domain.CalculatorDTO { Start = start, End = amount });

        response.Result.Should().BeOfType<OkObjectResult>();
    }

    [Theory, AutoData]
    public async Task Subtract_WithValidInput_Should_ReturnsOk(int start, int amount)
    {
        _calculatorUseCase.Setup(x => x.Subtract(start, amount)).ReturnsAsync(start - amount);

        var response = await _calculatorController.Subtract(new Domain.CalculatorDTO { Start = start, End = amount });

        response.Result.Should().BeOfType<OkObjectResult>();
    }

    [Theory, AutoData]
    public async Task Multiply_WithValidInput_Should_ReturnsOk(int start, int by)
    {
        _calculatorUseCase.Setup(x => x.Multiply(start, by)).ReturnsAsync(start * by);

        var response = await _calculatorController.Multiply(new Domain.CalculatorDTO { Start = start, End = by });

        response.Result.Should().BeOfType<OkObjectResult>();
    }

    [Theory, AutoData]
    public async Task Divide_WithValidInput_Should_ReturnsOk(int start, int by)
    {
        _calculatorUseCase.Setup(x => x.Divide(start, by)).ReturnsAsync(start / by);

        var response = await _calculatorController.Divide(new Domain.CalculatorDTO { Start = start, End = by });

        response.Result.Should().BeOfType<OkObjectResult>();
    }
}