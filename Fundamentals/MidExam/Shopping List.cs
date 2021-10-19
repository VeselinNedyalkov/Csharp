using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopingList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            string comands = Console.ReadLine();

            while (comands != "Go Shopping!")
            {
                string[] input = comands.Split(" ").ToArray();
                switch (input[0])
                {
                    case "Urgent":
                        if (!shopingList.Contains(input[1]))
                        {
                            shopingList.Insert(0 , input[1]);
                        }
                        break;
                    case "Unnecessary":
                        if (shopingList.Contains(input[1]))
                        {
                            shopingList.Remove(input[1]);
                        }
                        break;
                    case "Correct":
                        if (shopingList.Contains(input[1]))
                        {
                            for (int i = 0; i < shopingList.Capacity; i++)
                            {
                                if (shopingList[i].Contains(input[1]))
                                    shopingList[i] = input[2];
                            }
                        }
                        break;
                    case "Rearrange":
                        if (shopingList.Contains(input[1]))
                        {                           
                            shopingList.Remove(input[1]);
                            shopingList.Add(input[1]);
                            
                        }
                        break;
                    default:
                        break;
                }//switch
                comands = Console.ReadLine();
            }//while
            Console.Write(string.Join(", ", shopingList));
        }
    }
}
