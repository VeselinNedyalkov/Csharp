using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int counter = int.MinValue;
            int counterInFor = 0;
            int number = 0;

            //1 2 3 4
            for (int i = 0; i < numberArr.Length - 1; i++)
            {

                if (numberArr[i] == numberArr[i + 1])
                {
                    counterInFor++;
                    if (counterInFor > counter)
                    {
                        counter = counterInFor;
                        number = numberArr[i];
                    }
                }
                else
                {
                    counterInFor = 0;
                }
                
            }//for

            for (int k = 0; k <= counter; k++)
            {
                Console.Write($"{number} ");
            }

            if (number == 0)
            {
                number = numberArr[0];
                Console.WriteLine(number);
                
            }
        }
    }
}
