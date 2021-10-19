using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string[] operations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (operations[0] != "End")
            {
                switch (operations[0])
                {
                    case"Add":                       
                            numbers.Add(int.Parse(operations[1]));
                        break;

                    case "Insert":
                        if (int.Parse(operations[2]) <= numbers.Count-1 && int.Parse(operations[2]) >= 0)
                            numbers.Insert(int.Parse(operations[2]), int.Parse(operations[1]));
                        else
                            Console.WriteLine("Invalid index");
                        break;

                    case "Remove":
                        if (int.Parse(operations[1]) <= numbers.Count-1 && int.Parse(operations[1]) >= 0)
                            numbers.RemoveAt(int.Parse(operations[1]));
                        else
                            Console.WriteLine("Invalid index");
                        break;

                    case "Shift":                       
                            if (operations[1] == "left")
                            {
                                for (int i = 0; i < int.Parse(operations[2]); i++)
                                {
                                    int temp = numbers[0];
                                    numbers.Remove(numbers[0]);
                                    numbers.Add(temp);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < int.Parse(operations[2]); i++)
                                {
                                    int temp = numbers[numbers.Count - 1];
                                    numbers.RemoveAt(numbers.Count - 1);
                                    numbers.Insert(0, temp);
                                }
                            }                                                    
                        break;

                    default:
                        Console.WriteLine("Invalid index");
                        break;
                }//switch
                operations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }//while
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
