using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExamCAdvance
{
    public class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<int, string> coffeDrinks = new Dictionary<int, string>
            {
                { 50, "Cortado"},
                { 75,"Espresso"},
                { 100,"Capuccino"},
                { 150,"Americano"},
                { 200,"Latte"}
            };

            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> createdCoffe = new Dictionary<string , int> 
            {
                { "Cortado" , 0},
                { "Espresso", 0},
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0}
            };

            while (coffee.Count() != 0 )
            {
                if (milk.Count() == 0)
                {
                    break;
                }

                int coffeValue = coffee.Dequeue();
                int milkValue = milk.Pop();
                int sumCoffeeMilk = coffeValue + milkValue;

                if (coffeDrinks.ContainsKey(sumCoffeeMilk))
                {
                    createdCoffe[coffeDrinks[sumCoffeeMilk]]++;
                }
                else
                {
                    milkValue -= 5;
                    milk.Push(milkValue);
                }
            }

            if (coffee.Count() != 0 || milk.Count() != 0)
            {
                sb.AppendLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                sb.AppendLine("Nina is going to win! She used all the coffee and milk!");
            }

            sb.Append("Coffee left: ");
            string resultCoffe = coffee.Count == 0 ? "none" : string.Join(", ", coffee);
            sb.AppendLine(resultCoffe);

            sb.Append("Milk left: ");
            string resultMilk = milk.Count == 0 ? "none" : string.Join(", ", milk);
            sb.AppendLine(resultMilk);

            foreach (var drink in createdCoffe.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (drink.Value != 0)
                {
                    sb.AppendLine($"{drink.Key}: {drink.Value}");
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }
}
