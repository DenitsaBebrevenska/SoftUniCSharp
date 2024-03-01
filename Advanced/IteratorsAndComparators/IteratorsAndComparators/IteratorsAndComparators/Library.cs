using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> _books;
        public Library(params Book[] books)
        {
            _books = new SortedSet<Book>(books, new BookComparator());
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(_books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int _currentIndex = -1;
            private List<Book> _books;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                _books = new List<Book>(books);
            }
            public bool MoveNext()
            {
                return ++_currentIndex < _books.Count;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public Book Current => _books[_currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            { }
        }
    }
}
