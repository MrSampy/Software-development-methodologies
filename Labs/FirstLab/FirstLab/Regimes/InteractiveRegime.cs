using FirstLab.Solvers;


namespace FirstLab.Regimes
{
    public class InteractiveRegime:Regime
    {
        protected double GetCoeff(string coeffName) 
        {
            double result;
            while (true) 
            {
                Console.Write($"{coeffName} = ");
                var input = Console.ReadLine();
                try 
                {
                    result = Convert.ToDouble(input);
                }
                catch
                {
                    ErrorPrinter.PrintWrongInputError(coeffName, input);
                    continue;
                }

                if (result == 0 && coeffName.Equals(stringCoeffs.First())) 
                {
                    ErrorPrinter.PrintNotZeroError(coeffName);
                    continue;
                }

                return result;
            }
        
        
        }

        protected override Coeffs GetCoefficients()
        {
            var result = new double[stringCoeffs.Length];
            for (int id = 0; id < stringCoeffs.Length; ++id) 
            {
                result[id] = GetCoeff(stringCoeffs[id]);
            }
            return new Coeffs(result[0], result[1], result[2]);
        }
    }
}
