using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab.Solvers
{
    public class QuadraticEquationSolver
    {
        public Coeffs Coeffs;
        public QuadraticEquationSolver(Coeffs coeffs)
        {
            Coeffs= coeffs;
        }

        public List<double> Solve()
        {
            List<double> result;

            var preRoot = Coeffs.B * Coeffs.B - 4 * Coeffs.A * Coeffs.C;

            if (preRoot < 0)
            {
                result = new List<double>();
            }
            else if (preRoot == 0)
            {
                double x = -Coeffs.B / (2.0 * Coeffs.A);
                result = new List<double>
                {
                    x
                };
            }
            else
            {
                double x1 = (-Coeffs.B - Math.Sqrt(preRoot)) / (2 * Coeffs.A);
                double x2 = (-Coeffs.B + Math.Sqrt(preRoot)) / (2 * Coeffs.A);
                result = new List<double>
                {
                    x1,
                    x2
                };
            }
            return result;
        }


    }
}
