using System;

namespace _3._Generating_01_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Generator(arr, 0);
        }

        static void Generator(int[] arr,int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty,arr));
                return;
            }
                

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;

                Generator(arr, index + 1);
            }
        }
    }
}
