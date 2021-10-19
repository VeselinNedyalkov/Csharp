using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemos = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            
            while (pokemos.Count != 0)
            {
                int indexForRemuvePok = int.Parse(Console.ReadLine());
                int numberForRemove = 0;

                if (indexForRemuvePok < 0) //if the index is less than 0 then...
                {
                    numberForRemove = pokemos[0];
                    pokemos.RemoveAt(0);
                    int temp = pokemos[pokemos.Count - 1];                    
                    pokemos.Insert(0, temp);  
                    
                }
                else if (indexForRemuvePok > pokemos.Count - 1)//if index is more than the lenght of the List 
                {
                    numberForRemove = pokemos[pokemos.Count - 1];
                    pokemos.RemoveAt(pokemos.Count - 1);
                    int temp = pokemos[0];
                    pokemos.Add(temp);
                }
                else  //if is in range
                {
                    numberForRemove = pokemos[indexForRemuvePok];
                    pokemos.RemoveAt(indexForRemuvePok);
                }

                sum += numberForRemove;//add ther remove number to sum
               


                for (int i = 0; i < pokemos.Count; i++)//increase or decrease each of the numbers in the list
                {
                    if (numberForRemove >= pokemos[i])
                    {
                        pokemos[i] += numberForRemove;
                    }
                    else
                    {
                        pokemos[i] -= numberForRemove;
                    }                   
                }
                //Console.WriteLine(string.Join(" ",pokemos));
            }//while

            Console.WriteLine(sum);
        }//Main
    }
}
