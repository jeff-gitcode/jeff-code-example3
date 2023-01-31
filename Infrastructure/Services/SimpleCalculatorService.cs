using Application.Interface.SPI;

namespace Infrastructure.Services;

public class SimpleCalculatorService: ISimpleCalculator
{
    public SimpleCalculatorService()
    {
    }

    public int Add(int start, int amount)
    {
        return start + amount;
    }

    public int Subtract(int start, int amount)
    {
        return start - amount;
    }

    public int Multiply(int start, int by)
    {
        return start * by;
    }

    public int Divide(int start, int by)
    {
        return start / by;
    }
}