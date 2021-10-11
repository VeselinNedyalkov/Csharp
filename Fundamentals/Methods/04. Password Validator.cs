using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();//input string

            bool characters = CheckPassCharLenght(passwordInput);//check bool from the method CheckPassCharLenght
            if (characters == false)//if false print the message
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            bool letterDigits = CheckForLettersDigits(passwordInput);//check bool from method CheckForLettersDigits
            if (letterDigits == false)//if false print the message
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool twoDigits =  CheckForTwoDigits(passwordInput);//check boold from method CheckForTwoDigits
            if (twoDigits == false)//if false print the message
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (characters == true && letterDigits == true && twoDigits == true)//if all 3 are true print the message
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckPassCharLenght(string passwordInput)//method that check the lenght of the input to be from 6 to 10 char
        {
            bool result = false;//bool is false as default
            if (passwordInput.Length >= 6 && passwordInput.Length <= 10)
            {
                result = true;
            }
            return result;
        }

        static bool CheckForLettersDigits(string passwordInput)//check for letter and digits
        {
            bool result = true;
            passwordInput = passwordInput.ToLower();//make all letters lower case
            for (int i = 0; i < passwordInput.Length; i++)//check each simol with acsii table
            {
                if (passwordInput[i] < 48 || passwordInput[i] > 57 && passwordInput[i] < 97 || passwordInput[i] > 122)
                {
                    result = false;
                    break;
                }

            }
            return result;
        }

        static bool CheckForTwoDigits(string passwordInput)//check for atleast 2 digits
        {
            bool result = false;
            int digits = 0;
            for (int i = 0; i < passwordInput.Length; i++)
            {
                if (passwordInput[i] >= 48 && passwordInput[i] <= 57)//using acsii table
                {
                    digits++;
                }
            }

            if (digits >= 2)//if more than 2 pressent make true 
            {
                result = true;
            }
            return result;
        }
    }
}
