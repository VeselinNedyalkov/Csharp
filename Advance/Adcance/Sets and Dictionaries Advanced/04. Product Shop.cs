using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,double>> shopProducts = new Dictionary<string, Dictionary<string, double>>();

            string infoShop;
            while ((infoShop = Console.ReadLine()) != "Revision")
            {
                string[] dataShop = infoShop.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string shop = dataShop[0];
                string product = dataShop[1];
                double price =  double.Parse(dataShop[2]);

                if (shopProducts.ContainsKey(shop))
                {
                    if (shopProducts[shop].ContainsKey(product))
                    {
                        shopProducts[shop][product] = price;
                    }
                    else
                    {
                        shopProducts[shop].Add(product, price);
                    }
                }
                else
                {
                    shopProducts.Add(shop, new Dictionary<string, double>());
                    shopProducts[shop].Add(product, price);
                }
            }

            foreach (var shop in shopProducts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {       
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}






//Write a program that prints information about food shops in Sofia and the products they store.
// Until the "Revision" command is received, you will be receiving input in the format: "{shop}, {product}, {price}".
//  Keep in mind that if you receive a shop you already have received, you must collect its product information.
//Your output must be ordered by shop name and must be in the format:
//"{shop}->
//Product: { product}, Price: { price}


