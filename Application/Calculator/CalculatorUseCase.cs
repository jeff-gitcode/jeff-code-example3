using Application.Interface.API;
using Application.Interface.SPI;
using Domain;

namespace Application.Calculator
{
    public class CalculatorUseCase : ICalculatorUseCase
    {
        private readonly ISimpleCalculator _simpleCalculator;
        private readonly IDiagnosticsUseCase _diagnosticsUseCase;
        private readonly IDateTimeService _dateTimeService;

        public CalculatorUseCase(ISimpleCalculator simpleCalculator, IDiagnosticsUseCase diagnosticsUseCase, IDateTimeService dateTimeService)
        {
            _simpleCalculator = simpleCalculator;
            _diagnosticsUseCase = diagnosticsUseCase;
            _dateTimeService = dateTimeService;
        }

        public async Task<int> Add(int start, int amount)
        {
            // _ = Guard.Against.NegativeOrZero(start, nameof(start));
            // _ = Guard.Against.NegativeOrZero(amount, nameof(amount));

            int result = _simpleCalculator.Add(start, amount);

            await _diagnosticsUseCase.Log(new DiagnosticsDTO
            {
                Operation = $"{nameof(Add)}({start}, {amount})",
                Results = result,
                Created = _dateTimeService.UtcNow,
            });

            return result;
        }

        public async Task<int> Subtract(int start, int amount)
        {
            int result = _simpleCalculator.Subtract(start, amount);

            await _diagnosticsUseCase.Log(new DiagnosticsDTO
            {
                Operation = $"{nameof(Subtract)}({start}, {amount})",
                Results = result,
                Created = _dateTimeService.UtcNow,
            });

            return result;
        }

        public async Task<int> Multiply(int start, int by)
        {
            int result = _simpleCalculator.Multiply(start, by);

            await _diagnosticsUseCase.Log(new DiagnosticsDTO
            {
                Operation = $"{nameof(Multiply)}({start}, {by})",
                Results = result,
                Created = _dateTimeService.UtcNow,
            });

            return result;
        }

        public async Task<int> Divide(int start, int by)
        {
            int result = _simpleCalculator.Divide(start, by);

            await _diagnosticsUseCase.Log(new DiagnosticsDTO
            {
                Operation = $"{nameof(Divide)}({start}, {by})",
                Results = result,
                Created = _dateTimeService.UtcNow,
            });

            return result;
        }
    }
}