using System;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            //creat the pizza and check for Exception
            Pizza pizza;
            try
            {
                pizza = new Pizza(pizzaInfo[1]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //creat the dought and check for Exception
            string[] doughtInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dough dough;
            try
            {
                dough = new Dough(doughtInfo[1], doughtInfo[2], double.Parse(doughtInfo[3]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            pizza.Dough = dough;

            //creat the toping and add it to the pizza 
            
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] topingInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Topping toping;
                try
                {
                    toping = new Topping(topingInfo[1], double.Parse(topingInfo[2]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                //if is more than 10 => Exception
                try
                {
                    pizza.Toppings = toping;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");

        }
    }
}
