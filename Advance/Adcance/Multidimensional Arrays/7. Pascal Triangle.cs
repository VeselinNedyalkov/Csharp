using System;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            for (int i = 0; i < height; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    row[j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                }
                triangle[i] = row;
            }

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}


//The triangle may be constructed in the following manner: In row 0 (the topmost row),
// there is a unique nonzero entry 1. Each entry of each subsequent row is constructed by
// adding the number above and to the left with the number above and to the right,
//treating blank entries as 0. For example, the initial number in the first (or any other) 
//row is 1(the sum of 0 and 1), whereas the numbers 1 and 3 in the third row are added to produce 
//the number 4 in the fourth row.
//If you want more info about it: https://en.wikipedia.org/wiki/Pascal's_triangle
//Print each row elements separated with whitespace.
