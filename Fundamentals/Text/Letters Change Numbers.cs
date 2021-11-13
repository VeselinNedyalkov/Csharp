using System;
using System.Linq;
using System.Text;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;


            foreach (var word in input)
            {

                for (int i = 0; i < word.Length - 1; i++)
                {
                    if (char.IsUpper(word[i]) && char.IsDigit(word[i + 1]))             //if we have Uper letter and a num
                    {
                        string charDivider = "";
                        for (int k = i + 1; k < word.Length; k++)                      //take all the numbers to the next letter
                        {
                            if (char.IsDigit(word[k]))
                                charDivider += word[k];
                            else
                                break;

                        }

                        double number = double.Parse(charDivider);
                        double divider = word[i] - 64;

                        if (divider != 0)
                            sum += (number / divider);                                          //calc the sum
                    }
                    else if (char.IsLower(word[i]) && char.IsDigit(word[i + 1]))            //if we have lower letter and a num
                    {
                        string charMultiply = "";
                        for (int k = i + 1; k < word.Length; k++)                           //take all the numbers
                        {
                            if (char.IsDigit(word[k]))
                                charMultiply += word[k];
                            else
                                break;
                        }

                        double number = double.Parse(charMultiply);
                        double mulyiply = word[i] - 96;

                        sum += (number * mulyiply);                             //calc the sum

                    }
                    else if (char.IsDigit(word[i]) && char.IsUpper(word[i + 1]))
                    {
                        double subtract = word[i + 1] - 64;
                       
                        sum -= subtract;                             //calc the sum

                    }
                    else if (char.IsDigit(word[i]) && char.IsLower(word[i + 1]))
                    {
                        double add = word[i + 1] - 96; 
                        sum += add;                             //calc the sum

                    }
                }
            }//foreach
            Console.WriteLine($"{sum:f2}");

        }
    }
}
