using Domain;

namespace Application.Interface.API
{
    public interface ICalculatorUseCase
    {
        Task<int> Add(int start, int amount);
        Task<int> Subtract(int start, int amount);
        Task<int> Multiply(int start, int by);
        Task<int> Divide(int start, int by);
    }
}