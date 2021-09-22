using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string insertedMoney = Console.ReadLine();
            double insertedMoneyNum = 0;
            double totalMoney = 0;

            while (insertedMoney != "Start")
            {
                insertedMoneyNum = double.Parse(insertedMoney);
                if (insertedMoneyNum == 0.1 || insertedMoneyNum == 0.2 || insertedMoneyNum == 0.5 || insertedMoneyNum == 1 || insertedMoneyNum == 2)
                {
                    totalMoney += insertedMoneyNum;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {insertedMoney}");
                }
                insertedMoney = Console.ReadLine();
            }//while check the money input

            string order = Console.ReadLine();
            double orderMoney = 0;
            

            while (order != "End")
            {
                bool check = true;
                //"Nuts", "Water", "Crisps", "Soda", "Coke".
                //2.0,      0.7,     1.5,     0.8,    1.0
                switch (order)
                {
                    case "Nuts":
                        orderMoney = 2;
                        break;
                    case "Water":
                        orderMoney = 0.7;
                        break;
                    case "Crisps":
                        orderMoney = 1.5;
                        break;
                    case "Soda":
                        orderMoney = 0.8;
                        break;
                    case "Coke":
                        orderMoney = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        check = false;
                        break;                    
                }//switch price of stocks
                if (orderMoney <= totalMoney && check == true)//check if you have enought money
                {
                    Console.WriteLine($"Purchased {order.ToLower()}");
                    totalMoney -= orderMoney;
                }
                else if (check == true)            
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                
                orderMoney = 0;
                order = Console.ReadLine();
            }//while cicle for orders

            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
