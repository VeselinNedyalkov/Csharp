using System;
using System.Linq;
using System.Collections.Generic;

namespace Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //input format Peter=11;George=4
            List<Person> people = new List<Person>();
            string[] persons = Console.ReadLine().Split(";");
            //split the persons to array
            for (int i = 0; i < persons.Length; i++)
            {
                //take the person with index i
                string name = persons[i];
                //faind the index of =
                int index = name.IndexOf('=');
                //separate the number
                int money = int.Parse(name.Substring(index + 1));
                //add substring with the name , money and default product
                people.Add(new Person(name.Substring(0, index), money, "Nothing bought"));
            }

            List<Product> products = new List<Product>();
            string[] productsForSell = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            //same as for persons just for products
            for (int i = 0; i < productsForSell.Length; i++)
            {
                string nameProduct = productsForSell[i];
                int index = nameProduct.IndexOf('=');               
                int price = int.Parse(nameProduct.Substring(index + 1));
                products.Add(new Product(nameProduct.Substring(0, index), price));
            }
            

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] buy = cmd.Split();
                string personsName = buy[0];
                string productName = buy[1];
                //we take the byer and the product
                Person buyer = people.Single(x => x.Name == personsName);
                Product product = products.Single(x => x.Name == productName);

                //if money are not enought
                if ((buyer.Money - product.Cost) < 0)                
                    Console.WriteLine($"{personsName} can't afford {productName}");
                else
                {
                    //if money are enought remove the cost
                    buyer.Money -= product.Cost;

                    //if the person products have the default value remove it
                    if (buyer.Products[0] == "Nothing bought")
                        buyer.Products.Clear();

                    //add the product to the person and print
                    buyer.Products.Add(productName);
                    Console.WriteLine($"{personsName} bought {productName}");
                }
                
            }

            foreach (var man in people)
            {
                Console.WriteLine($"{man.Name} - {string.Join(", ", man.Products)}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<string> Products { get; set; }

        public Person(string name, int money, string product)
        {
            Name = name;
            Money = money;
            Products = new List<string> { product };
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
