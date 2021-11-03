using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();

            string[] inputPerson = Console.ReadLine().Split();

            while (inputPerson[0] != "End")
            {
                string name = inputPerson[0];
                string Id = inputPerson[1];
                int age = int.Parse(inputPerson[2]);
                Person personClass = new Person(name, Id, age);
                personList.Add(personClass);

                inputPerson = Console.ReadLine().Split();
            }

            personList = personList.OrderBy(personsAge => personsAge.Age).ToList();

            foreach (Person person in personList)
            {
                Console.WriteLine(person);
            }
        }
    }//class program

    class Person
    {
        public Person(string name , string Id , int age)
        {
            Name = name;
            ID = Id;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

}
