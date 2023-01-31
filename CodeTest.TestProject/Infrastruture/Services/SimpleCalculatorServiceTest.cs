using FluentAssertions;
using Infrastructure.Services;

namespace CodeTest.TestProject.Infrastruture.Services;

public class SimpleCalculatorServiceTest
{
    private readonly SimpleCalculatorService _sut;

    public SimpleCalculatorServiceTest()
    {
        _sut = new SimpleCalculatorService();
    }

    [Fact]
    public void Add_WhenCalled_Should_Return()
    {
        var start = 1;
        var amount = 2;

        var result = _sut.Add(start, amount);

        result.Should().Be(3);
        
    }

    [Fact]
    public void Subtract_WhenCalled_Should_Return()
    {
        var start = 3;
        var amount = 2;

        var result = _sut.Subtract(start, amount);

        result.Should().Be(1);
    }

    [Fact]
    public void Multiply_WhenCalled_Should_Return()
    {
        var start = 1;
        var by = 2;

        var result = _sut.Multiply(start, by);

        result.Should().Be(2);
    }

    [Fact]
    public void Divide_WhenCalled_Should_Return()
    {
        var start = 4;
        var by = 2;

        var result = _sut.Divide(start, by);

        result.Should().Be(2);
    }
}