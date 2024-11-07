using System.ComponentModel.DataAnnotations;

namespace CalcApp.Server.Models
{
    public class OperationModel
    {
        [Key]
        public uint Id { get; set; }
        public double FirstElement { get; set; }
        public uint SecondElement { get; set; }
        public CalculationMethods CalculationMethod { get; set; }
        public string? Result { get; set; }
    }
    public enum CalculationMethods
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Pow,
        Root
    }
}
