using System;
using System.Linq;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
       
        private Person person;

        private Person[] persons;
        private Database database;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }
        [Test]
        public void CheckWhetherCountEqualsArrayLength()
        {
            Person[] persons = new Person[]
            {
                new Person(12, "Pesho"),
                new Person(13, "Gesho"),
                new Person(1335, "Sesho"),
            };

            database = new Database(persons);
            Assert.AreEqual(persons.Length, database.Count);
        }

        [Test]
        public void CheckWhetherCanAddPersonsWhenCountIsBelow16()
        {
            person = new Person(1565656, "Gecata");
            Person[] persons = new Person[]
            {
                new Person(12, "Pesho"),
                new Person(13, "Gesho"),
                new Person(1335, "Sesho"),
            };

            database = new Database(persons);
            database.Add(person);
            Assert.AreEqual(4, database.Count);
        }
        [Test]
        public void ThrowExceptionWhenAddRangeNumberIsAbove16()
        {
            persons = new Person[16];
            Person person = new Person(1222, "Toko");
            database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(1 + i, $"Pesho {i}"));
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(person), "Array's capacity must be exactly 16 integers!");

        }
        [Test]
        public void ThrowExceptionWhenCapacityOf16IsExceeeded()
        {

            persons = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(1 + i, $"Pesho {i}");
            }

         
            Assert.Throws<ArgumentException>(()=> database = new Database(persons), "Provided data length should be in range [0..16]!");

        }
        [Test]
        public void ThrownExceptionWhenPersonWithThisUsernameExists()
        {
            person = new Person(333, "aaa");
            persons = new Person[] {new Person(111, "aaa"), new Person(222, "bbb")};
            database = new Database(persons);

            Assert.Throws<InvalidOperationException>(() => database.Add(person),
                "There is already user with this username!");

        }
        [Test]
        public void ThrowExceptionWhenPersonWithThisIdExists()
        {
            person = new Person(222, "aa");
            persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb") };
            database = new Database(persons);

            Assert.Throws<InvalidOperationException>(() => database.Add(person),
                "There is already user with this Id!");

        }
        [Test]
        public void RemoveElementsWhenArrayNotEmpty()
        {
           persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb"), new Person(33333, "Gecata")};
            database = new Database(persons);
            database.Remove();
            Assert.AreEqual(2, database.Count);
            Assert.That(persons, Does.Not.Contain((33333, "Gecata")));
        }
        [Test]
        public void ThrowExceptionAtRemoveMehtodWhenCountIsZero()
        {
            persons = Array.Empty<Person>();
            database = new Database(persons);
            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }
        
        [TestCase("")]
        [TestCase(null)]
        public void ThrownExceptionWhenUsernameIsNullOrEmpty(string username)
        {
            persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb"), new Person(33333, "Gecata") };
           database = new Database(persons);


            Assert.Throws<ArgumentNullException>(() =>  database.FindByUsername(username),
                "Username parameter is null!");
        }
        [TestCase("Dimitrichko")]
        [TestCase("Valyo")]
        public void ThrownExceptionWhenUsernameIsNotPresentInArray(string username)
        {
           
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username),
                "No user is present by this username!");
        }
        [TestCase("Gecata")]
        [TestCase("aaa")]
        public void FindExistingPersonByUsernameInArray(string username)
        {
            persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb"), new Person(33333, "Gecata") };
            database = new Database(persons);
           
            Assert.That(persons.FirstOrDefault(x => x.UserName == username), Is.EqualTo(database.FindByUsername(username)));
        }
        [TestCase(-1)]
        public void ThrownExceptionWhenIdIsBelowZero(long id)
        {
            persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb"), new Person(33333, "Gecata") };
           database = new Database(persons);


            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id),
                "Id should be a positive number!");
        }
        [TestCase(1)]
        [TestCase(2222222)]
        public void ThrownExceptionWhenNoIdPresentInArray(long id)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(id),
                "No user is present by this ID!");
        }
        [TestCase(222)]
        [TestCase(111)]
        public void FindPersonByExistingIdInArray(long id)
        {
            persons = new Person[] { new Person(111, "aaa"), new Person(222, "bbb"), new Person(33333, "Gecata") };
            database = new Database(persons);

            Assert.That(persons.FirstOrDefault(x => x.Id == id), Is.EqualTo(database.FindById(id)));
        }
       
      

    }
}
