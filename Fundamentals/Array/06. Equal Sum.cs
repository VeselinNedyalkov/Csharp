using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < array.Length; i++)
            {


                if (array.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                //if (array.Length == 2)
                //{
                //    Console.WriteLine(0);
                //    return;
                //}


                //leftSum
                leftSum = 0;
                for (int k = i; k > 0; k--)
                {
                    int tempoNumber = (k - 1);
                    if (k > 0)
                    {
                        leftSum += array[tempoNumber];
                    }
                    
                }


                //rightSum
                rightSum = 0;
                for (int j = i; j < array.Length; j++)
                {
                    int tempoNumber = (j + 1);
                    if (j < array.Length - 1)
                    {
                        rightSum += array[tempoNumber];
                    }
                    
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
