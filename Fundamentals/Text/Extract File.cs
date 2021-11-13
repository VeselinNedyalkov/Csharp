using System;
using System.Linq;


namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = input.LastIndexOf("\\");
            int dotIndex = input.LastIndexOf(".");

            string fileName = input.Substring(index + 1 , dotIndex - index - 1);
            string fileExtension = input.Substring(dotIndex + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
