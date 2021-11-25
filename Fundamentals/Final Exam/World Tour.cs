using System;
using System.Text;

namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder locations = new StringBuilder(Console.ReadLine());
            
            string cmd;
            while ((cmd = Console.ReadLine()) != "Travel")
            {
                string[] cmdString = cmd.Split(':');

                switch (cmdString[0])
                {
                    case "Add Stop":
                        int index = int.Parse(cmdString[1]);
                        string addString = cmdString[2];
                        if(index >= 0 && index < locations.Length)
                            locations.Insert(index, addString);
                        break;

                    case "Remove Stop":
                        int startIndex = int.Parse(cmdString[1]);
                        int endIndex = int.Parse(cmdString[2]);
                        int indexLenght = endIndex - startIndex + 1;
                        if(startIndex >= 0 && endIndex < locations.Length)
                            locations.Remove(startIndex, indexLenght);
                        break;

                    case "Switch":
                        string onldString = cmdString[1];
                        string newString = cmdString[2];
                        locations.Replace(onldString, newString);
                        break;

                    default:
                        break;
                }
                Console.WriteLine(locations.ToString());
            }//while
            Console.WriteLine($"Ready for world tour! Planned stops: {locations.ToString()}");
        }
    }
}
