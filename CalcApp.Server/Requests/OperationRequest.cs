using CalcApp.Server.Models;

namespace CalcApp.Server.Requests
{
    public record OperationRequest(uint FirstElement, uint SecondElement, CalculationMethods CalculationMethod, string? Result);
}
