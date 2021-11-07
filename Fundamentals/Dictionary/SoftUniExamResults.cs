
using System;
using System.Collections.Generic;
using System.Linq;


namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> examResults = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();


       
            string inputData = Console.ReadLine();

            while (inputData != "exam finished")
            {
                //You will be receiving lines in the following format:
                //"{username}-{language}-{points}" until you receive "exam finished".
                //You should store each username and his submissions and points.
                string[] input = inputData.Split("-");
                if (input.Length == 3)
                {
                    string user = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);

                    if (!examResults.ContainsKey(user))
                        examResults.Add(user, points);
                    
                     if(examResults[user] < points)                   
                        examResults[user] = points;

                    if (!submissions.ContainsKey(language))
                        submissions.Add(language, 0);

                    submissions[language]++;
                }
                else
                {
                    //You can receive a command to ban a user for cheating in the following format: "{username}-banned".In that case, you should remove the
                    //user from the contest, but preserve his submissions in the total count of submissions for each language.
                    string user = input[0];

                    if (examResults.ContainsKey(user))
                        examResults.Remove(user);
                }
                inputData = Console.ReadLine();
            }//while

            //After receiving "exam finished" print each of the participants,
            //ordered descending by their max points, then by username, in the following format:

            Console.WriteLine("Results:");

            foreach (var user in examResults.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            //After that print each language, used in the exam,
            //ordered descending by total submission count and then by language name, in the following format:

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
