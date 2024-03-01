using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listy
{
    public  class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> _list;
        private int _index = 0;
        public ListyIterator(params T[] items)
        {
            _list = items.ToList();
        }

        public bool Move()
        {
            return ++_index < _list.Count;
        }

        public bool HasNext()
        {
            return _index + 1 < _list.Count;
        }

        public void Print()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }

            Console.WriteLine(_index >= _list.Count ? _list[^1] : _list[_index]);
        }

        public void PrintAll()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }

            foreach (T item in _list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                yield return _list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
