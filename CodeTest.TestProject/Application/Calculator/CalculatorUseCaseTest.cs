using Application.Calculator;
using Application.Interface.API;
using Application.Interface.SPI;
using AutoFixture.Xunit2;
using Domain;
using FluentAssertions;
using MediatR;
using Moq;

namespace CodeTest.TestProject.Application.Calculator;

public class CalculatorUseCaseTest
{
    private readonly Mock<ISimpleCalculator> _simpleCalculatorMock;
    private readonly Mock<IDiagnosticsUseCase> _diagnosticsUseCaseMock;
    private readonly Mock<IDateTimeService> _dateTimeServiceMock;
    private readonly CalculatorUseCase _calculatorUseCase;

    public CalculatorUseCaseTest()
    {
        _simpleCalculatorMock = new Mock<ISimpleCalculator>();
        _diagnosticsUseCaseMock = new Mock<IDiagnosticsUseCase>();
        _dateTimeServiceMock = new Mock<IDateTimeService>();
        _calculatorUseCase = new CalculatorUseCase(_simpleCalculatorMock.Object, _diagnosticsUseCaseMock.Object, _dateTimeServiceMock.Object);
    }

    [Fact]
    public async Task Add_WhenCalled_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 1;
        int amount = 2;
        int expectedResult = 3;
        _simpleCalculatorMock.Setup(x => x.Add(start, amount)).Returns(expectedResult);

        // Act
        int result = await _calculatorUseCase.Add(start, amount);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task Add_WhenCalled_ShouldLogCorrectly()
    {
        // Arrange
        int start = 1;
        int amount = 2;
        int expectedResult = 3;
        _simpleCalculatorMock.Setup(x => x.Add(start, amount)).Returns(expectedResult);
        string expectedOperation = $"Add({start}, {amount})";
        _dateTimeServiceMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

        // Act
        int result = await _calculatorUseCase.Add(start, amount);

        // Assert
        _diagnosticsUseCaseMock.Verify(x => x.Log(It.Is<DiagnosticsDTO>(y => y.Operation == expectedOperation && y.Results == expectedResult)), Times.Once);
    }

    [Fact]
    public async Task Subtract_WhenCalled_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 2;
        int amount = 1;
        int expectedResult = 1;
        _simpleCalculatorMock.Setup(x => x.Subtract(start, amount)).Returns(expectedResult);

        // Act
        int result = await _calculatorUseCase.Subtract(start, amount);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task Subtract_WhenCalled_ShouldLogCorrectly()
    {
        // Arrange
        int start = 2;
        int amount = 1;
        int expectedResult = 1;
        _simpleCalculatorMock.Setup(x => x.Subtract(start, amount)).Returns(expectedResult);
        string expectedOperation = $"Subtract({start}, {amount})";
        _dateTimeServiceMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

        // Act
        int result = await _calculatorUseCase.Subtract(start, amount);

        // Assert
        _diagnosticsUseCaseMock.Verify(x => x.Log(It.Is<DiagnosticsDTO>(y => y.Operation == expectedOperation && y.Results == expectedResult)), Times.Once);
    }

    [Fact]
    public async Task Multiply_WhenCalled_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 2;
        int by = 2;
        int expectedResult = 4;
        _simpleCalculatorMock.Setup(x => x.Multiply(start, by)).Returns(expectedResult);

        // Act
        int result = await _calculatorUseCase.Multiply(start, by);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task Multiply_WhenCalled_ShouldLogCorrectly()
    {
        // Arrange
        int start = 2;
        int by = 2;
        int expectedResult = 4;
        _simpleCalculatorMock.Setup(x => x.Multiply(start, by)).Returns(expectedResult);
        string expectedOperation = $"Multiply({start}, {by})";
        _dateTimeServiceMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

        // Act
        int result = await _calculatorUseCase.Multiply(start, by);

        // Assert
        _diagnosticsUseCaseMock.Verify(x => x.Log(It.Is<DiagnosticsDTO>(y => y.Operation == expectedOperation && y.Results == expectedResult)), Times.Once);
    }

    [Fact]
    public async Task Divide_WhenCalled_ShouldReturnCorrectResult()
    {
        // Arrange
        int start = 4;
        int by = 2;
        int expectedResult = 2;
        _simpleCalculatorMock.Setup(x => x.Divide(start, by)).Returns(expectedResult);

        // Act
        int result = await _calculatorUseCase.Divide(start, by);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task Divide_WhenCalled_ShouldLogCorrectly()
    {
        // Arrange
        int start = 4;
        int by = 2;
        int expectedResult = 2;
        _simpleCalculatorMock.Setup(x => x.Divide(start, by)).Returns(expectedResult);
        string expectedOperation = $"Divide({start}, {by})";
        _dateTimeServiceMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

        // Act
        int result = await _calculatorUseCase.Divide(start, by);

        // Assert
        _diagnosticsUseCaseMock.Verify(x => x.Log(It.Is<DiagnosticsDTO>(y => y.Operation == expectedOperation && y.Results == expectedResult)), Times.Once);
    }
}