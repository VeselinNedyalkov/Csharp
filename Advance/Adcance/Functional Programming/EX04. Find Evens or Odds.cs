using System;
using System.Linq;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> odd = x => x % 2 != 0;
            Predicate<int> even = x => x % 2 == 0;


            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
            string oper = Console.ReadLine();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                switch (oper)
                {
                    case "odd":
                        if(odd(i))
                            Console.Write(i + " ");
                        break;

                    case "even":
                        if (even(i))
                            Console.Write(i + " ");
                        break;

                    default:
                        break;
                }
            }            
        }     
    }
}



//You are given a lower and an upper bound for a range of integer numbers. 
//Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate<T>.

