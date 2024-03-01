using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethod
{
    public class GenericCount<T> where T : IComparable
    {
        public int CountGreaterValues(List<T> list, T element)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
