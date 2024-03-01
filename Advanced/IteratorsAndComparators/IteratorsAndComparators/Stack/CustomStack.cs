using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> _elements = new List<T>();

        public void Push(List<T> elements)
        {
            _elements.AddRange(elements);
        }

        public T Pop()
        {
            if (_elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return default;
            }

            T elementToPop = _elements[^1];
            _elements.RemoveAt(_elements.Count - 1);

            return elementToPop;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _elements.Count - 1; i >= 0; i--)
            {
                yield return _elements[i];
            }

            for (int i = _elements.Count - 1; i >= 0; i--)
            {
                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
