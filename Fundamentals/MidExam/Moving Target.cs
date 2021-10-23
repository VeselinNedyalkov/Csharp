using System;
using System.Collections.Generic;
using System.Linq;

namespace Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetsSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                switch (cmd[0])
                {
                    case "Shoot":
                        int indexShot = int.Parse(cmd[1]);
                        int powerShot = int.Parse(cmd[2]);

                        if (indexShot < 0 || indexShot > targetsSequence.Count -1 ) break;      //check the index


                        if (targetsSequence[indexShot] - powerShot <= 0)                        //if si less or equal to 0 remuve
                            targetsSequence.RemoveAt(indexShot);
                        else
                            targetsSequence[indexShot] -= powerShot;                            //else just reduce
                        break;

                    case "Add":
                        int indexAdd = int.Parse(cmd[1]);
                        int value = int.Parse(cmd[2]);
                        if (indexAdd < 0 || indexAdd > targetsSequence.Count - 1)               //check index
                        {
                            Console.WriteLine("Invalid placement!");
                            break;
                        }
                        else
                            targetsSequence.Insert(indexAdd, value);                            //insert
                        break;

                    case "Strike":
                        int indexStrike = int.Parse(cmd[1]);
                        int radius = int.Parse(cmd[2]);
                        if (indexStrike - radius < 0 || indexStrike + radius > targetsSequence.Count - 1)       //check the index
                            Console.WriteLine("Strike missed!");
                        else
                            targetsSequence.RemoveRange(indexStrike - radius, (radius * 2) + 1);                //hit and remuveALL from the index - radius to doble the radius + the hit number

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }//while
            Console.WriteLine(string.Join("|", targetsSequence));
        }//Main
    }
}
