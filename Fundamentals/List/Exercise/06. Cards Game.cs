using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneCards = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> playerTwoCards = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            CardCompare(playerOneCards, playerTwoCards);
        }//main

        static void CardCompare(List<int> playerOneCards, List<int> playerTwoCards)
        {
            while (playerOneCards.Count > 0 && playerTwoCards.Count > 0)
            {
                if (playerOneCards[0] == playerTwoCards[0])
                {
                    playerOneCards.RemoveAt(0);
                    playerTwoCards.RemoveAt(0);
                }
                else if (playerOneCards[0] > playerTwoCards[0])
                {
                    playerOneCards.Add(playerOneCards[0]);
                    playerOneCards.Add(playerTwoCards[0]);
                    playerOneCards.RemoveAt(0);
                    playerTwoCards.RemoveAt(0);
                }
                else
                {
                    playerTwoCards.Add(playerTwoCards[0]);
                    playerTwoCards.Add(playerOneCards[0]);
                    playerTwoCards.RemoveAt(0);
                    playerOneCards.RemoveAt(0);

                }
            }//while
            if (playerOneCards.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwoCards.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {playerOneCards.Sum()}");
            }
        }
    }
}
