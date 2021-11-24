using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //we create the dictionary
            SortedDictionary<string, string[]> composers = new SortedDictionary<string, string[]>();

            int num = int.Parse(Console.ReadLine());
            //intput num numbers of inputs
            for (int i = 0; i < num; i++)
            {
                string[] inputData = Console.ReadLine().Split("|");
                string piece = inputData[0];
                string composer = inputData[1];
                string key = inputData[2];

                if (!composers.ContainsKey(piece))
                    composers.Add(piece,new string[2]);
                if (composers.ContainsKey(piece))
                {
                    composers[piece][0] = composer;
                    composers[piece][1] = key;
                }
                    
            }
            //follow the comands
            string comands;
            while ((comands = Console.ReadLine()) != "Stop")
            {
                string[] data = comands.Split("|");
                string cmd = data[0];


                switch (cmd)
                {
                    case "Add":
                        string piece = data[1];
                        string composer = data[2];
                        string key = data[3];
                        if (!composers.ContainsKey(piece))
                        {
                            composers.Add(piece, new string[2]);
                            composers[piece][0] = composer;
                            composers[piece][1] = key;
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                            Console.WriteLine($"{piece} is already in the collection!");
                        break;

                    case "Remove":
                        piece = data[1];
                        if (composers.ContainsKey(piece))
                        {
                            composers.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;

                    case "ChangeKey":
                        piece = data[1];
                        string newKey = data[2];
                        if (composers.ContainsKey(piece))
                        {
                            composers.Remove(composers[piece][1]);
                            composers[piece][1] = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        break;

                    default:
                        break;
                }
            }//while

            foreach (var piece in composers.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                
                 Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
                
            }
        }
    }
}

