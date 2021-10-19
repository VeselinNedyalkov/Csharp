using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] comands = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (comands[0] != "course start")                    //while the course start
            {
                switch (comands[0])                                //check what is comand
                {
                    case "Add":
                        if (courses.Contains(comands[1])) break;    //if the list contain the lesson break

                        courses.Add(comands[1]);                    //if is not in the list add
                        //Console.WriteLine(string.Join(" ", courses));
                        break;

                    case "Insert":
                        if (courses.Contains(comands[1])) break;    //if the list contain the lesson break

                        courses.Insert(int.Parse(comands[2]), comands[1]);//insert if is not in the list
                        //Console.WriteLine(string.Join(" ", courses));
                        break;

                    case "Remove":
                        if (!courses.Contains(comands[1])) break;   //if the lesson is missing break

                        courses.Remove(comands[1]);                 //if the list contain remove

                        if (courses.Contains($"{comands[1]}-Exercise"))//check for Exercise
                        {
                            int indexOfExercise = courses.IndexOf($"{comands[1]}-Exercise");
                            courses.RemoveAt(indexOfExercise);
                        }
                        
                        //Console.WriteLine(string.Join(" ", courses));
                        break;

                    case "Swap":                
                        if (!courses.Contains(comands[1])) break;   //check for 1st lesson if is missing break
                        if (!courses.Contains(comands[2])) break;   //che for 2nd lesson if is missing break

                        for (int i = 0; i < courses.Count; i++)     //swap the lessons
                        {
                            if (courses[i] == comands[1])
                                courses[i] = comands[2];
                            else if (courses[i] == comands[2])
                                courses[i] = comands[1];                            
                        }
                        
                        if (courses.Contains($"{comands[1]}-Exercise"))//move the Exercise if the lesson have one
                        {                             
                            int indexOfLeson = courses.IndexOf(comands[1]);
                            int indexOfExercise = courses.IndexOf($"{comands[1]}-Exercise");
                            courses.Insert(indexOfLeson + 1, courses[indexOfExercise]);
                            courses.RemoveAt(indexOfExercise + 1);
                        }
                        else if (courses.Contains($"{comands[2]}-Exercise"))
                        {
                            int indexOfLeson = courses.IndexOf(comands[2]);
                            int indexOfExercise = courses.IndexOf($"{comands[2]}-Exercise");
                            courses.Insert(indexOfLeson + 1, courses[indexOfExercise]);
                            courses.RemoveAt(indexOfExercise + 1);
                        }
                            
                        //Console.WriteLine(string.Join(" ",courses));
                        break;

                    case "Exercise":    
                        if (!courses.Contains(comands[1])) courses.Add(comands[1]);//if we don`t have lesson for the exercise add one
                        if (courses.Contains($"{comands[1]}-Exercise")) break;

                        int indexOfLessson = courses.IndexOf(comands[1]);
                        courses.Insert(indexOfLessson + 1, $"{comands[1]}-Exercise");

                        //Console.WriteLine(string.Join(" ", courses));
                        break;
                    default:
                        break;
                }

                comands = Console.ReadLine().Split(":");
            }//while

            for (int i = 0; i < courses.Count; i++)                     //print the end List               
            {
                Console.WriteLine($"{i+1}.{courses[i]}");
            }
        }//Main
    }
}
