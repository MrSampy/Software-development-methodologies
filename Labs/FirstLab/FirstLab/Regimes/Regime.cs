using FirstLab.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab.Regimes
{
    public abstract class Regime
    {
        private QuadraticEquationSolver QuadraticEquationSolver { get; set; }
        protected abstract Coeffs GetCoefficients();

        public void PrintSolution() 
        {
            var realCoeffs = GetCoefficients();

            QuadraticEquationSolver = new QuadraticEquationSolver(realCoeffs);
        
            var result = QuadraticEquationSolver.Solve();

            Console.WriteLine($"There are {result.Count} roots");
            for (int id = 0; id < result.Count; ++id) 
            {
                Console.WriteLine($"x{id+1} = {result[id]}");
            }

        }

    }
}
