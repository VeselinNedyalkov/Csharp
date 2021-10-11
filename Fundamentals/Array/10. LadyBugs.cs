using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] indexOfLadybugs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string comands = Console.ReadLine();
            int[] field = new int[sizeOfField];
            int weHaveABugHere = 1;


            for (int i = 0; i < indexOfLadybugs.Length; i++)//posiotion the Ladybugs on field
            {
                if (indexOfLadybugs[i] < field.Length && indexOfLadybugs[i] >= 0)
                {
                    int positionOfBugs = indexOfLadybugs[i];
                    field[positionOfBugs] = weHaveABugHere;
                }

            }

            while (comands != "end")//check for end word
            {
                string[] comandsArray = comands.Split(" ", StringSplitOptions.RemoveEmptyEntries);//take array of strings
                int indexForMove = int.Parse(comandsArray[0]);//1st comand
                string directions = comandsArray[1];//second comand
                int flyLenght = int.Parse(comandsArray[2]);// 3rd comand
                int isItZero = 0;
                bool doneMoving = false;

                if (field[indexForMove] == 0) //check if we have Ladybugs on this index and to be inside the array
                {
                    comands = Console.ReadLine();
                    continue;
                }
                if (indexForMove < 0 || indexForMove > field.Length-1)
                {
                    comands = Console.ReadLine();
                    continue;
                }
                switch (directions)//check moving left or right
                {
                    case "left":
                        field[indexForMove] = 0;
                        isItZero = indexForMove - flyLenght;
                        while (doneMoving != true)//check when move for 1
                        {
                            if (isItZero < 0 || flyLenght == 0)//if go out of array break
                            {
                                break;
                            }
                            else if (field[isItZero] == 1)//reduce by 1 till find 0
                            {
                                isItZero -= flyLenght;
                            }
                            else//its zero make it 1 and break the cicle
                            {
                                field[isItZero] = 1;
                                doneMoving = true;
                            }
                        }
                        break;
                    case "right":
                        field[indexForMove] = 0;
                        isItZero = indexForMove + flyLenght;
                        while (doneMoving != true)//check when move for 1
                        {
                            if (isItZero > field.Length - 1 || flyLenght == 0)//if go out of array breack
                            {
                                break;
                            }
                            else if (field[isItZero] == 1)//increase  by 1 till find 0
                            {
                                isItZero += flyLenght;
                            }
                            else//its 0 make it 1 and break the cicle
                            {

                                field[isItZero] = 1;
                                doneMoving = true;
                            }
                        }
                        break;
                    default:
                        break;
                }//switch
                comands = Console.ReadLine();//take new comand
            }//while
            
            Console.WriteLine(string.Join(" ", field));
        }//main       
    }//class
}


