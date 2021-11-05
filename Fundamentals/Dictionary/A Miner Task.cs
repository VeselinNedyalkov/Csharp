using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resorces = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string valueInput = Console.ReadLine();

                if (!resorces.ContainsKey(input))
                {
                    resorces.Add(input, 0);
                }
                resorces[input] += int.Parse(valueInput);

                input = Console.ReadLine();
            }

            foreach (var item in resorces)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
