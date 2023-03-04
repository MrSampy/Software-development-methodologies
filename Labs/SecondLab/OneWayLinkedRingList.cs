using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab
{
    internal class OneWayLinkedRingList<T>
    {
        internal Node<T>? Head { get; private set; }
        internal Node<T>? Tail { get; private set; }

        public int Count { get; private set; }
    }
}
