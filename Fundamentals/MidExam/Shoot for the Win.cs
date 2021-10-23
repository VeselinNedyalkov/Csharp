using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> shotTargts = Console.ReadLine().Split().Select(int.Parse).ToList();

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                int IndexShotTarget = int.Parse(cmd);
                if (IndexShotTarget >= 0 && IndexShotTarget < shotTargts.Count)
                {
                    if (shotTargts[IndexShotTarget] != -1)
                    {
                        int targetValue = shotTargts[IndexShotTarget];
                        shotTargts[IndexShotTarget] = -1;
                        for (int i = 0; i < shotTargts.Count; i++)
                        {
                            if (shotTargts[i] != -1)
                            {
                                if (shotTargts[i] > targetValue)
                                    shotTargts[i] -= targetValue;
                                else
                                    shotTargts[i] += targetValue;
                            }
                        }
                    }
                }
                              
                cmd = Console.ReadLine();
            }//while
            Console.Write($"Shot targets: {shotTargts.Count(x => x == -1)} ");
            Console.WriteLine($"-> {string.Join(" ", shotTargts)}");
        }
    }
}
