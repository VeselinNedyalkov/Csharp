

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            
            while (inputNumber != "END")
            {
                string reverceNum = string.Empty;
                for (int i = inputNumber.Length - 1; i >= 0; i--)
                {
                    reverceNum += inputNumber[i];
                }

                bool answer = false;

                if (inputNumber == reverceNum)
                {
                    answer = true;
                }

                Console.WriteLine(answer);
                inputNumber = Console.ReadLine();
            }
            
            
        }

       
    }
}
