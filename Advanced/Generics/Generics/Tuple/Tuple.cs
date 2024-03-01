using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    public class Tuple<TValue1, TValue2>
    {
        public TValue1 Value1 { get; set; }

        public TValue2 Value2 { get; set; }

        public Tuple(TValue1 value1, TValue2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public override string ToString()
        {
            return $"{Value1} -> {Value2}";
        }
    }
}
