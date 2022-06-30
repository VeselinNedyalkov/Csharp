using System;
using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
       
        [Test]
        [TestCase(7)]
        [TestCase(15)]
        [TestCase(16)]
        
        public void CheckWhetherCanAddElementsWhenTheyAreBelow16(int count)
        {
            Database database = new Database();
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(count, database.Count);
           
        }
        [Test]
        
        public void CheckForExceptionWhenElementsAre16()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(()=> database.Add(1));
        }
        [Test]
        [TestCase(1, 8)]
        public void CheckWhetherCanRemoveElementsWhenArrayNotEmpty(int start, int count)
        {
            int[] array = Enumerable.Range(start, count).ToArray();
            Database database = new Database(array);
            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }
            Assert.AreEqual(0, database.Count);

        }
        [Test]
        public void CheckForExceptionWhileRemovingAndArrCountIsZero()
        {
            int[] array = Array.Empty<int>();

            Database database = new Database(array);
           
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void CheckIfFetchReturnsElementsAsArray()
        {
            int[] array = new int[16];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            Database database = new Database(array);
            database.Fetch();
            Assert.AreEqual(array, database.Fetch());
        }
    }
}
