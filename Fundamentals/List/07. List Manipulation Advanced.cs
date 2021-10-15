using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool changes = false;

            while (input[0] != "end")
            {
                switch (input[0])
                {
                    case "Contains":
                        if (numbers.Contains(int.Parse(input[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        
                        break;
                    case "PrintEven":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                Console.Write($"{numbers[i]} ");
                            }
                        }
                        Console.WriteLine();
                        
                        break;
                    case "PrintOdd":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 1)
                            {
                                Console.Write($"{numbers[i]} ");
                            }
                        }
                        Console.WriteLine();
                        
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                       
                        break;
                    case "Filter":
                        Filter(input[1], int.Parse(input[2]), numbers);
                        
                        break;
                    case "Add":
                        numbers.Add(int.Parse(input[1]));
                        changes = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(input[1]));
                        changes = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(input[1]));
                        changes = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        changes = true;
                        break;
                    default:
                        break;
                   
                }//switch
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }//while

            if (changes)
                Console.WriteLine(string.Join(" ", numbers));
        }//main

        static void Filter(string simvol , int borderNum, List<int> numbers)
        {
            if (simvol == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > borderNum)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                Console.WriteLine();
            }
            else if (simvol == "<" )
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < borderNum)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                Console.WriteLine();
            }
            else if (simvol == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= borderNum)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                    
                }
                Console.WriteLine();
            }
            else if (simvol == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= borderNum)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
