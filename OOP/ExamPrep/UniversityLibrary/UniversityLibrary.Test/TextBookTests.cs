using System.Text;

namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class TextBookTests
    {
        private TextBook book;
        private string title = "The Hobbit";
        private string author = "J.R.R.Tolkien";
        private string category = "Fantasy";
        private int inventoryNumber = 1;
        [SetUp]
        public void Setup()
        {
            book = new TextBook(title, author, category);
        }

        [Test]
        public void Constructor_ShouldInitializeBook()
        {
            Assert.IsNotNull(book);
        }

        [Test]
        public void Constructor_ShouldSetTitleAuthorAndCategory()
        {
            Assert.AreEqual(book.Title, title);
            Assert.AreEqual(book.Author, author);
            Assert.AreEqual(book.Category, category);
        }

        [Test]
        public void ToString_ShouldReturnCorrectly()
        {
            book.InventoryNumber = inventoryNumber;
            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine($"Book: {title} - {inventoryNumber}");
            expectedResult.AppendLine($"Category: {category}");
            expectedResult.AppendLine($"Author: {author}");

            Assert.AreEqual(expectedResult.ToString().TrimEnd(), book.ToString());
        }
    }
}