using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int[] firstArr = new int[inputNum];
            int[] secondArr = new int[inputNum];


            for (int i = 0; i < inputNum; i++)
            {
                int[] probaArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int num1 = probaArr[0];
                int num2 = probaArr[1];

                if (i % 2 == 0)
                {
                    firstArr[i] = num1;
                    secondArr[i] = num2;
                }
                else
                {
                    firstArr[i] = num2;
                    secondArr[i] = num1;
                }

            } 
            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
