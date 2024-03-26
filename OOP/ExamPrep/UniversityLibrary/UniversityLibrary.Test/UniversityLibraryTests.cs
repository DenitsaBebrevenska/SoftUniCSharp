using System.Linq;

namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class UniversityLibraryTests
    {
        private UniversityLibrary library;
        private TextBook book;
        private string title = "The Hobbit";
        private string author = "J.R.R.Tolkien";
        private string category = "Fantasy";
        private string student = "Peter";
        [SetUp]
        public void Setup()
        {
            book = new TextBook(title, author, category);
            library = new UniversityLibrary();
        }

        [Test]
        public void Constructor_ShouldInitializeLibrary()
        {
            Assert.IsNotNull(library);
        }

        [Test]
        public void Constructor_ShouldInitializeCatalogue()
        {
            Assert.IsNotNull(library.Catalogue);
        }

        [Test]
        public void AddTextBookToLibrary_ShouldSetInventoryNumberCorrectly()
        {
            library.AddTextBookToLibrary(book);
            Assert.AreEqual(library.Catalogue.Count, book.InventoryNumber);
        }

        [Test]
        public void AddTextBookToLibrary_ShouldAddBookToCatalogue()
        {
            Assert.IsFalse(library.Catalogue.Contains(book));
            library.AddTextBookToLibrary(book);
            Assert.IsTrue(library.Catalogue.Contains(book));
        }

        [Test]
        public void AddTextBookToLibrary_ShouldReturnCorrectString()
        {
            book.InventoryNumber = 1;
            string expectedResult = book.ToString();
            Assert.AreEqual(expectedResult, library.AddTextBookToLibrary(book));
        }

        [Test]
        public void LoanTextBook_ShouldGetFirstOrDefaultBookWithGivenId()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            Assert.AreSame(book, library.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1));
        }

        [Test]
        public void LoanTextBook_ShouldSetBookHolderCorrectly()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            Assert.IsNotNull(book.Holder);
            Assert.AreEqual(student, book.Holder);
        }

        [Test]
        public void LoanTextBook_ShouldCorrectlyReturn_WhenSuccessfullyLoaning()
        {
            string expectedString = $"{title} loaned to {student}.";
            library.AddTextBookToLibrary(book);
            Assert.AreEqual(expectedString, library.LoanTextBook(1, student));
        }

        [Test]
        public void LoanTextBook_ShouldCorrectlyReturn_WhenBookIsStillNotReturned()
        {
            string expectedResult = $"{student} still hasn't returned {title}!";
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            Assert.AreEqual(student, book.Holder);
            Assert.AreEqual(expectedResult, library.LoanTextBook(1, student));
        }

        [Test]
        public void ReturnTextBook_ShouldGetFirstOrDefaultBookWithGivenId()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            library.ReturnTextBook(1);
            Assert.AreSame(book, library.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1));
        }

        [Test]
        public void ReturnTextBook_ShouldSetHolderBackToEmpty()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            library.ReturnTextBook(1);
            Assert.AreSame(string.Empty, library.Catalogue.FirstOrDefault(b => b.InventoryNumber == 1).Holder);
        }

        [Test]
        public void ReturnTextBook_ShouldCorrectlyReturnString()
        {
            library.AddTextBookToLibrary(book);
            library.LoanTextBook(1, student);
            string expectedResult = $"{title} is returned to the library.";
            Assert.AreEqual(expectedResult, library.ReturnTextBook(1));
        }
    }
}