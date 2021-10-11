using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rotationNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotationNum; i++)
            {
                int number = arr[0];
                for (int k = 0; k < arr.Length - 1; k++)
                {
                    arr[k] = arr[k + 1];
                }

                arr[arr.Length - 1] = number;
            }

            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
