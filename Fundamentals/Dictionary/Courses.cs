using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ",StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);

                input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            courses = courses.OrderByDescending(n => n.Value.Count).ToDictionary(x => x.Key, x => x.Value);          

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                var sortedList = course.Value.OrderBy(x => x).ToList();
                for (int i = 0; i < sortedList.Count; i++)
                {
                    Console.WriteLine($"-- {sortedList[i]}");
                }
                
            }
        }
    }
}
