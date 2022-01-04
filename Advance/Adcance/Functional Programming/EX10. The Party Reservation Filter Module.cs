using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries));
            List<string> partyList = new List<string>(names);
            //filters
            Func<string, string, bool> startWith = (name, start) => name.StartsWith(start);
            Func<string, string, bool> endWith = (name, end) => name.EndsWith(end);
            Func<string, string, bool> wordLenght = (name, len) => name.Length == int.Parse(len);
            Func<string, string, bool> containWord = (name, word) => name.Contains(word);

            //comands
            Action<string> add = name => partyList.Add(name);
            Action<string> remove = name => partyList.Remove(name);
            

            string cmd;
            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] data = cmd.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string comand = data[0];
                string filter = data[1];
                string value = data[2];

                switch (filter)
                {
                    case "Starts with":
                        if (comand == "Add filter")
                            PartReserv(startWith, names, remove, value);
                        if(comand == "Remove filter")
                            PartReserv(startWith, names, add, value);
                        break;

                    case "Ends with":
                        if (comand == "Add filter")
                            PartReserv(endWith, names, remove, value);
                        if (comand == "Remove filter")
                            PartReserv(endWith, names, add, value);
                        break;

                    case "Length":
                        if (comand == "Add filter")
                            PartReserv(wordLenght, names, remove, value);
                        if (comand == "Remove filter")
                            PartReserv(wordLenght, names, add, value);
                        break;

                    case "Contains":
                        if (comand == "Add filter")
                            PartReserv(containWord, names, remove, value);
                        if (comand == "Remove filter")
                            PartReserv(containWord, names, add, value);
                        break;

                    default:
                        break;
                }
            }//while

            Console.WriteLine(string.Join(" ", partyList));
        }

        private static void PartReserv(Func<string, string, bool> filter, List<string> names, Action<string> comand
            , string value)
        {
            foreach (var name in names)
            {
                if (filter(name, value))
                    comand(name);
            }
        }
    }
}



//You need to implement a filtering module to a party reservation software. 
//First, the Party Reservation Filter Module (PRFM for short) is passed a list
//with invitations. 
//Next, the PRFM receives a sequence of commands that specify whether 
//you need to add or remove a given filter.
//Each PRFM command is in the given format:
//"{command;filter type;filter parameter}"
//You can receive the following PRFM commands: 
//•	"Add filter"
//•	"Remove filter"
//•	"Print"
//The possible PRFM filter types are: 
//•	"Starts with"
//•	"Ends with"
//•	"Length"
//•	"Contains"
//All PRFM filter parameters will be a string (or an integer only for the "Length" filter). 
//Each command will be valid e.g. you won’t be asked to remove a non-existent filter.
// The input will end with a "Print" command, after which you should print all the 
//party-goers that are left after the filtration. See the examples below:

