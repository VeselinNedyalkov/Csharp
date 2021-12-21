using System;
using System.Linq;
using System.Collections.Generic;

namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray());

            Console.WriteLine(orders.ToArray().Max());

            while (orders.Count > 0)
            {
                if ((foodQuantity - orders.Peek()) >= 0)
                    foodQuantity -= orders.Dequeue();
                else
                    break;
            }
            
            

            if (orders.Count == 0)
                Console.WriteLine("Orders complete");
            else
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        }
    }
}
