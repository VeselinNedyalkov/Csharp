using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> bomb = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            while (numbers.Contains(bomb[0]))//while we have the bomb/numbers
            {
                int index = numbers.IndexOf(bomb[0]);//index of the bomb
                int rotatiotnRight = 0;

                if (index + bomb[1] > numbers.Count - 1)//if we go out of list
                {
                    rotatiotnRight = numbers.Count;
                }
                else
                {
                    rotatiotnRight = index + bomb[1] + 1;
                }

                for (int i = index; i < rotatiotnRight; i++)//remuve bomb to right
                {
                    numbers.RemoveAt(index);
                    //Console.WriteLine(string.Join(" ", numbers));
                }

                int rotatiotnLeft = 0;
                if (index - bomb[1] < 0)
                {
                    rotatiotnLeft = 0;
                }
                else
                {
                    rotatiotnLeft = index - bomb[1];
                }
                for (int i = index; i > rotatiotnLeft; i--)//remuve bomb to left
                {
                   numbers.RemoveAt(i - 1);
                   //Console.WriteLine(string.Join(" ", numbers));                   
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
