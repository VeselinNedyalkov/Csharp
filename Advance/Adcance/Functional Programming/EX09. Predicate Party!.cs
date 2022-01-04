using System;
using System.Linq;
using System.Collections.Generic;

namespace Predicate_Party_
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //declare a list of string and fill it from console
            List<string> names = new List<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));          
            
            //make 3 delegates to test the conditions
            Func<string, string, bool> startWith = (name, start) => name.StartsWith(start);
            Func<string , string , bool> endWith = (name, end) => name.EndsWith(end);
            Func<string, string, bool> wordLenght = (name, len) => name.Length == int.Parse(len);

            //two delegates to add or remuve
            Action<string> doubl = name => names.Add(name);
            Action<string> remove = name => names.Remove(name);            

            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                string[] data = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string order = data[0];
                string typeDelegate = data[1];
                string keyWord = data[2];

                switch (typeDelegate)
                {
                    case "StartsWith":
                        if(order == "Remove")
                            IsGoing(startWith, names, remove, keyWord);
                        if(order == "Double")
                            IsGoing(startWith, names, doubl, keyWord);
                        break;

                    case "EndsWith":
                        if (order == "Remove")
                            IsGoing(endWith, names, remove, keyWord);
                        if (order == "Double")
                            IsGoing(endWith, names, doubl, keyWord);
                        break;

                    case "Length":
                        if (order == "Remove")
                            IsGoing(wordLenght, names, remove, keyWord);
                        if (order == "Double")
                            IsGoing(wordLenght, names, doubl, keyWord);
                        break;

                    default:
                        break;
                }
            }

            
            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ", names) + " are going to the party!");
            }
        }

        public static void IsGoing(Func<string, string, bool> deleg, List<string> names, Action<string> adRem, string keyWord)
        {
            //before start make one temp list and read it!
            List<string> temp = new List<string>(names);

            foreach (var name in temp)
            {
                //do the changes to the list - names
                if (deleg(name, keyWord))
                {
                    adRem(name);                   
                }
                    
            }
        }
    }
}



//Ivan’s parents are on a vacation for the holidays and he is planning an epic party at home. 
//Unfortunately, his organizational skills are next to non-existent,
//so you are given the task to help him with the reservations.
//On the first line, you receive a list of all the people that are coming. 
//On the next lines, until you get the "Party!" command,
//you may be asked to double or remove all the people that apply to the given criteria.
// There are three different criteria: 
//•	Everyone that has his name starting with a given string
//•	Everyone that has a name ending with a given string
//•	Everyone that has a name with a given length.
//Finally, print all the guests who are going to the party separated by ", " 
//and then add the ending "are going to the party!". 
//If no guests are going to the party print "Nobody is going to the party!". 





