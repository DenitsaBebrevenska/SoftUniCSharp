using ExtendedDatabase;
using Enumerable = System.Linq.Enumerable;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Person extraPerson = new Person(16, "Henry16");
        private Database database;

        [SetUp]
        public void SetUp()
        {
            people = new Person[]
            {
                new(1, "Henry1"),
                new(2, "Henry2"),
                new(3, "Henry3"),
                new(4, "Henry4"),
                new(5, "Henry5"),
                new(6, "Henry6"),
                new(7, "Henry7"),
                new(8, "Henry8"),
                new(9, "Henry9"),
                new(10, "Henry10"),
                new(11, "Henry11"),
                new(12, "Henry12"),
                new(13, "Henry13"),
                new(14, "Henry14"),
                new(15, "Henry15"),
            };
        }

        [Test]
        public void Adding_People_Through_The_Constructor_Should_Set_Count_Correctly()
        {
            database = new Database(people);
            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void Adding_More_Than_16_People_Through_The_Constructor_Should_Throw_An_Exception()
        {
            Person[] extraPeople = new Person[] { new(16, "Henry16"), new(17, "Henry17") };
            Person[] tooManyPeople = Enumerable.ToArray(Enumerable.Concat(people, extraPeople));

            ArgumentException exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    database = new Database(tooManyPeople);
                }, "Adding more than 16 people through the constructor did not throw an exception");
            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message);
        }

        [Test]
        public void Count_Property_Should_Return_Correct_Count_Of_The_Collection()
        {
            database = new Database(people);
            Assert.AreEqual(people.Length, database.Count, "Count property did not return correct count");
        }

        [Test]
        public void Adding_A_Person_Should_Add_Them_To_The_Collection()
        {
            database = new Database(people);
            database.Add(extraPerson);
            Assert.AreEqual(extraPerson, database.FindByUsername(extraPerson.UserName), "The person was not added");
        }

        [Test]
        public void Adding_A_Person_Should_Increase_Count_Correctly()
        {
            database = new Database(people);
            database.Add(extraPerson);
            Assert.AreEqual(people.Length + 1, database.Count, "Count was not increased correctly when adding a person");
        }

        [Test]
        public void Find_By_Username_Should_Be_Case_Sensitive()
        {
            database = new Database(extraPerson);
            Assert.AreNotEqual("hEnRy16", extraPerson.UserName);
        }

        [Test]
        public void Trying_To_Add_A_Person_When_The_List_Is_Full_Should_Throw_An_Exception()
        {
            Person[] extraPeople = new Person[] { new(16, "Henry16") };
            Person[] tooManyPeople = Enumerable.ToArray(Enumerable.Concat(people, extraPeople));
            database = new Database(tooManyPeople);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.Add(new Person(10000, "Adam"));
                }, "Adding a person to full list should throw an exception");

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void Trying_To_Add_A_Person_With_A_Name_That_Already_Exists_Should_Throw_An_Exception()
        {
            database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.Add(new Person(1, "Henry1"));
                }, "Adding a person with a name that already exists should throw an exception");

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void Trying_To_Add_A_Person_With_Id_That_Already_Exists_Should_Throw_An_Exception()
        {
            database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.Add(new Person(1, "Asd"));
                }, "Adding a person with ID that already exists should throw an exception");

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void Removing_A_Person_Should_Correctly_Remove_Them_From_The_Collection()
        {
            database = new Database(people);
            Person removedPerson = people[^1];
            database.Remove();
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.FindByUsername(removedPerson.UserName);
                }, "The person was not removed");
        }

        [Test]
        public void Removing_A_Person_Should_Correctly_Decrease_Count()
        {
            database = new Database(people);

            database.Remove();
            Assert.AreEqual(people.Length - 1, database.Count, "The Count was not decreased correctly upon the removal of a person");
        }

        [Test]
        public void Removing_A_Person_When_The_Collection_Is_Empty_Should_Throw_An_Exception()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.Remove();
                }, "Removing a person from an empty collection should throw an exception");
        }

        [Test]
        public void Finding_User_By_Username_Should_Return_The_Correct_Person()
        {
            database = new Database(extraPerson);
            Assert.AreEqual(extraPerson, database.FindByUsername("Henry16"), "FindByUsername did not return the correct person");
        }

        [Test]
        public void Finding_User_By_Username_Should_Throw_An_Exception_If_Given_Null_Name_Argument()
        {
            database = new Database(people);

            Assert.Throws<ArgumentNullException>(
               () =>
               {
                   database.FindByUsername(null);
               }, "Giving a null as argument doesn`t throw an exception");
        }

        [Test]
        public void Finding_User_By_Username_Should_Throw_An_Exception_If_The_Name_Argument_Does_Not_Exist()
        {
            database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.FindByUsername("ASD");
                });
            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void Finding_User_By_Id_Should_Return_The_Correct_Person()
        {
            database = new Database(extraPerson);
            Assert.AreEqual(extraPerson, database.FindById(16), "FindById did not return the correct person");
        }

        [TestCase(-10)]
        [TestCase(-100)]
        public void Finding_User_By_Id_Should_Throw_An_Exception_If_Given_Id_Is_A_Negative_Number(int id)
        {
            database = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    database.FindById(id);
                }, "A negative number Id should throw an exception");
        }

        [Test]
        public void Finding_User_By_Id_Should_Throw_An_Exception_If_The_Id_Argument_Does_Not_Exist()
        {
            database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () =>
                {
                    database.FindById(666);
                });
            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
}