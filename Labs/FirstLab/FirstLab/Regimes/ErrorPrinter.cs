using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstLab.Regimes
{
    public class ErrorPrinter
    {
        public static void PrintWrongInputError(string name, string? input)
            => Console.WriteLine($"Error. Expected {name} valid real number, got {input} instead");
        public static void PrintNotZeroError(string coeffName) => Console.WriteLine($"Error. {coeffName} cannot be 0");
    }
}
