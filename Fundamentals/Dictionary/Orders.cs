using System;
using System.Collections.Generic;

using System.Linq;


namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();

            string[] inputProducts = Console.ReadLine().Split();

            while (inputProducts[0] != "buy")
            {
                string product = inputProducts[0];
                double price = double.Parse(inputProducts[1]);
                double quantity = double.Parse(inputProducts[2]);
                

                if (products.ContainsKey(product))
                {
                    products[product][1] += quantity;
                    products[product][0] = price;
                }
                else 
                {
                    products.Add(product, new double[] { price, quantity });
                }
                                                           
                inputProducts = Console.ReadLine().Split();
            }//while
            
            foreach (var item in products)
            {
                double totalPrice = products[item.Key][0] * products[item.Key][1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
