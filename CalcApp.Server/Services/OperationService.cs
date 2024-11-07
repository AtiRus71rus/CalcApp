using CalcApp.Server.Models;
using MediatR;

namespace CalcApp.Server.Services
{
    public class OperationService
    {
        //процесс вычисления данных
        public string? GetResult(uint firstElement, uint secondElement, CalculationMethods calculationMethod, string? result)
        {
            var operation = new OperationModel
            {
                FirstElement = firstElement,
                SecondElement = secondElement,
                CalculationMethod = calculationMethod
            };
            switch (operation.CalculationMethod)
            {
                case CalculationMethods.Addition:
                    result = (operation.FirstElement + operation.SecondElement).ToString();
                    break;
                case CalculationMethods.Subtraction:
                    result = (operation.FirstElement - operation.SecondElement).ToString();
                    break;
                case CalculationMethods.Multiplication:
                    result = (operation.FirstElement * operation.SecondElement).ToString();
                    break;
                case CalculationMethods.Division:
                    result = (operation.FirstElement / operation.SecondElement).ToString();
                    break;
                case CalculationMethods.Pow:
                    result = Math.Pow(operation.FirstElement, operation.SecondElement).ToString();
                    break;
                case CalculationMethods.Root:
                    result = Math.Pow(operation.FirstElement, 1 / operation.SecondElement).ToString();
                    break;
                default:
                    throw new ArgumentException();
            }
            operation.Result = result;
            return operation.Result;
        }
    }
}
