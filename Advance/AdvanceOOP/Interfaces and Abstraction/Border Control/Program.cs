using System;
using System.Collections.Generic;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IId> ids = new List<IId>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] data = cmd.Split();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    Citezen citizen = new Citezen(name, age, id);
                    ids.Add(citizen);
                }
                else
                {
                    string model = data[0];
                    string id = data[1];
                    Robot robot = new Robot(model , id);
                    ids.Add(robot);
                }
            }

            string searchedObj = Console.ReadLine();

            foreach (var objects in ids)
            {
                if (objects.Id.EndsWith(searchedObj))
                {
                    Console.WriteLine(objects.Id);
                }
            }
        }
    }
}
