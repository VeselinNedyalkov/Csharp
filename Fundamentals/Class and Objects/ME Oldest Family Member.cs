using System;
using System.Linq;
using System.Collections.Generic;

namespace Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int members = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < members; i++)
            {
                string[] member = Console.ReadLine().Split();
                string name = member[0];
                int age = int.Parse(member[1]);
                
                family.AddMember(new Person(name, age));
            }
            //we call the motod in Family to faind the oldest member
            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
    class Family
    {               

        List<Person> familly = new List<Person>();
        public void AddMember (Person member)
        {
            familly.Add(member);
        }

        public Person GetOldestMember()
        {           
                return familly.OrderByDescending(x => x.Age).First();           
           
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }
    }
}
