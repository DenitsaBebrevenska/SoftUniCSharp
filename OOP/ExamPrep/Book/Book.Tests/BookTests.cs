namespace Book.Tests
{
    using NUnit.Framework;
    using System;

    public class BookTests
    {
        private Book book;
        private string name = "The Hobbit";
        private string author = "J.R.R. Tolkien";
        private int footnoteNumber1 = 1;
        private string footnoteText1 = "Gandalf's wisdom lit paths through darkness";
        private int footnoteNumber2 = 2;
        private string footnoteText2 = "Smeagol race is unknown";

        [SetUp]
        public void SetUp()
        {
            book = new Book(name, author);
        }

        [Test]
        public void Constructor_ShouldInitializeBook()
        {
            Assert.IsNotNull(book);
        }

        [Test]
        public void Name_ShouldBeSetAndReturnCorrectly()
        {
            Assert.AreEqual(name, book.BookName);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Name_ShouldThrowException_WhenTryingToSetItToNullOrEmpty(string invalidName)
        {
            Book invalidBook;
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                invalidBook = new Book(invalidName, author));
            Assert.AreEqual($"Invalid {nameof(invalidBook.BookName)}!", exception.Message);
        }

        [Test]
        public void Author_ShouldBeSetAndReturnCorrectly()
        {
            Assert.AreEqual(author, book.Author);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Author_ShouldThrowException_WhenTryingToSetItToNullOrEmpty(string invalidAuthor)
        {
            Book invalidBook;
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                invalidBook = new Book(name, invalidAuthor));
            Assert.AreEqual($"Invalid {nameof(invalidBook.Author)}!", exception.Message);
        }
        [Test]
        public void FootNoteCount_ShouldBeSetToZeroInitially()
        {
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void AddNote_ShouldIncreaseFootNoteCount()
        {
            int initialCount = book.FootnoteCount;
            book.AddFootnote(footnoteNumber1, footnoteText1);
            Assert.AreEqual(++initialCount, book.FootnoteCount);
            book.AddFootnote(footnoteNumber2, footnoteText2);
            Assert.AreEqual(++initialCount, book.FootnoteCount);
        }

        [Test]
        public void AddFootnote_ShouldThrowException_WhenFootNoteNumberAlreadyExists()
        {
            book.AddFootnote(footnoteNumber1, footnoteText1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                book.AddFootnote(footnoteNumber1, footnoteText2));
            Assert.AreEqual("Footnote already exists!", exception.Message);
        }

        [Test]
        public void FindFootNote_ShouldReturnCorrectString()
        {
            book.AddFootnote(footnoteNumber1, footnoteText1);
            book.AddFootnote(footnoteNumber2, footnoteText2);
            string expectedResult = $"Footnote #{footnoteNumber1}: {footnoteText1}";
            Assert.AreEqual(expectedResult, book.FindFootnote(footnoteNumber1));
        }

        [Test]
        public void FindFootNote_ShouldThrowException_WhenFootNoteNumberDoesNotExists()
        {
            book.AddFootnote(footnoteNumber1, footnoteText1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                book.FindFootnote(footnoteNumber2));
            Assert.AreEqual("Footnote doesn't exists!", exception.Message);
        }

        [Test]
        public void AlterFootnote_ShouldChangeFootNoteText()
        {
            book.AddFootnote(footnoteNumber1, footnoteText1);
            string expectedResult = $"Footnote #{footnoteNumber1}: {footnoteText1}";
            Assert.AreEqual(expectedResult, book.FindFootnote(footnoteNumber1));
            book.AlterFootnote(footnoteNumber1, footnoteText2);
            string alteredResult = $"Footnote #{footnoteNumber1}: {footnoteText2}";
            Assert.AreEqual(alteredResult, book.FindFootnote(footnoteNumber1));
        }

        [Test]
        public void AlterFootnote_ShouldThrowException_WhenFootNoteNumberDoesNotExists()
        {
            book.AddFootnote(footnoteNumber1, footnoteText1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                book.AlterFootnote(footnoteNumber2, footnoteText2));
            Assert.AreEqual("Footnote does not exists!", exception.Message);
        }

    }
}