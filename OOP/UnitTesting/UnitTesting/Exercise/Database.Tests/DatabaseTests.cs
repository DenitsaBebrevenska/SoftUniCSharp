using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] array15Elements = Enumerable.Range(1, 15).ToArray();
        private int[] array16Elements = Enumerable.Range(1, 16).ToArray();
        private int[] array17Elements = Enumerable.Range(1, 17).ToArray();

        [Test]
        public void Constructor_Should_Set_Array_Field_Correctly()
        {
            database = new Database(array16Elements);
            int[] fetchedArray = database.Fetch();
            Assert.NotNull(database);
            Assert.AreEqual(array16Elements, fetchedArray, "The arrays are not the same");
        }

        [Test]
        public void Constructor_Should_Set_Count_Property_Correctly()
        {
            database = new Database(array15Elements);
            Assert.AreEqual(array15Elements.Length, database.Count, "The counts are not the same");
        }

        [Test]
        public void
            Constructor_Should_Throw_Exception_If_An_Array_Of_More_Than_16_Elements_Is_Given()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database = new Database(array17Elements);
                }, "Array's capacity must be exactly 16 integers!");
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void Count_Property_Should_Return_Correct_Count_Of_Array_Elements()
        {
            database = new Database(array15Elements);
            Assert.AreEqual(array15Elements.Length, database.Count,
                "The count of the array elements and the array set through the constructor do not match.");
        }

        [Test]
        public void If_Array_Has_16_Elements_Trying_To_Add_An_Element_Should_Throw_Exception()
        {
            int elementToAdd = 20;
            database = new Database(array16Elements);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                {
                    database = new Database(array17Elements);
                }, "Array's capacity must be exactly 16 integers!");
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void Adding_An_Element_Should_Increase_The_Count_Correctly()
        {
            database = new Database(array15Elements);
            Assert.AreEqual(array15Elements.Length, database.Count, "Count does not increase when adding an element");
        }

        [Test]
        public void Adding_An_Element_Should_Add_It_At_The_End_Of_The_Collection()
        {
            database = new Database(array15Elements);
            database.Add(16);
            Assert.AreEqual(array16Elements, database.Fetch(), "The element was not added at the end of the collection");
        }

        [Test]
        public void Removing_An_Item_Should_Remove_The_Last_One_From_The_Collection()
        {
            database = new Database(array16Elements);
            database.Remove();
            Assert.AreEqual(array15Elements, database.Fetch());
        }

        [Test]
        public void Removing_An_Item_Should_Decrease_Count_Correctly()
        {
            database = new Database(array16Elements);
            database.Remove();
            Assert.AreEqual(array16Elements.Length - 1, database.Count);
        }
        [Test]
        public void If_Array_Is_Empty_Removing_An_Item_Should_Throw_An_Exception()
        {
            database = new Database();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.Remove();
                }, "Removing an item from empty collection should throw an exception");
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [Test]
        public void Fetch_Method_Should_Return_Correctly_The_Collection()
        {
            database = new Database(array16Elements);
            Assert.AreEqual(array16Elements, database.Fetch(), "Fetch does not return the collection correctly");
        }
    }
}
