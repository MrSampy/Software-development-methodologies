using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab.Solvers
{
    public class Coeffs
    {
        public double A { set; get; }
        public double B { set; get; }
        public double C { set; get; }

        public Coeffs(double a = 0, double b = 0, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
