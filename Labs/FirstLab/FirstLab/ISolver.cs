using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    public interface ISolver<T>
    {
        public T Solve();

    }
}
