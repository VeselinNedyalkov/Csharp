using System;
using System.Linq;
using System.Collections.Generic;

namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceBulets = int.Parse(Console.ReadLine());
            int clip = int.Parse(Console.ReadLine());


            int[] bulets = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> buletsQ = new Stack<int>(bulets);

            int[] locks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> lockStack = new Queue<int>(locks);

            int profit = int.Parse(Console.ReadLine());
            int totalBulets = 0;

            while (buletsQ.Count != 0 && lockStack.Count != 0)
            {
                //remove the bulet and check the size of the lock
                int shotSiza = buletsQ.Pop();
                totalBulets++;
                int sizeLock = lockStack.Peek();

                //if you can open the lock remove it 
                if (shotSiza <= sizeLock)
                {
                    Console.WriteLine("Bang!");
                    lockStack.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                //reloading if we have more bulets
                if(totalBulets % clip == 0 && buletsQ.Count != 0)
                    Console.WriteLine("Reloading!");
            }


            //if we finish all the bulets but some lock are left close
            if (buletsQ.Count == 0 && lockStack.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockStack.Count}");
            }
            else
            {
                profit -= totalBulets * priceBulets;
                Console.WriteLine($"{buletsQ.Count} bullets left. Earned ${profit}");
            }
        }
    }
}


//•	On the first line of input, you will receive the price of each bullet – an integer in the range [0-100]
//•	On the second line, you will receive the size of the gun barrel – an integer in the range [1-5000]
//•	On the third line, you will receive the bullets – a space-separated integer sequence with [1-100] integers
//•	On the fourth line, you will receive the locks – a space-separated integer sequence with [1-100] integers
//•	On the fifth line, you will receive the value of the intelligence – an integer in the range [1-100000]
//After Sam receives all of his information and gear (input), he starts to shoot the locks front-to-back, while going through the bullets back-to-front.
//If the bullet has a smaller or equal size to the current lock, print "Bang!", then remove the lock. If not, print "Ping!", leaving the lock intact. The bullet is removed in both cases.
//If Sam runs out of bullets in his barrel, print "Reloading!" on the console, then continue shooting. If there aren’t any bullets left, don’t print it.
//The program ends when Sam either runs out of bullets, or the safe runs out of locks.
//Output
//•	 If Sam runs out of bullets before the safe runs out of locks, print:
//"Couldn't get through. Locks left: {locksLeft}"
//•	If Sam manages to open the safe, print:
//"{bulletsLeft} bullets left. Earned ${moneyEarned}"
//Make sure to account for the price of the bullets when calculating the money earned.

