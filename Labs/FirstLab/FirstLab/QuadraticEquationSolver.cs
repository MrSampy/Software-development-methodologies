using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    public class QuadraticEquationSolver:ISolver<List<double>>
    {

        private double A { set; get; }
        private double B { set; get; }
        private double C { set; get; }

        public QuadraticEquationSolver(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }

        public List<double> Solve() 
        {
            List<double> result;

            var preRoot = B * B - 4 * A * C;

            if (preRoot < 0)
            {
                result = new List<double>();
            }
            else if (preRoot == 0) 
            {
                double x = -B / (2.0 * A);
                result = new List<double> 
                {
                    x
                };
            }
            else 
            {
                var d = B * B - 4 * A * C;
                double x1 = (-B - Math.Sqrt(d)) / (2 * A);
                double x2 = (-B + Math.Sqrt(d)) / (2 * A);
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
