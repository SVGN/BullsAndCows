using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    class ScoreBoard
    {
        readonly static SortedList<int, string> scoreBoard = new SortedList<int, string>();

        public static void TryAddToScoreboard(int attempts)
        {
            if (scoreBoard.Count < 5 || scoreBoard.ElementAt(4).Key > attempts)
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                string name = Console.ReadLine().Trim();

                scoreBoard.Add(attempts, name);
                if (scoreBoard.Count == 6)
                    scoreBoard.RemoveAt(5);

                DisplayTop();
            }
        }

        public static void DisplayTop()
        {
            if (scoreBoard.Count() > 0)
            {
                Console.WriteLine("Scoreboard:");
                int position = 1;
                foreach (var score in scoreBoard)
                {
                    Console.WriteLine("{0}. {1} --> {2} guesses", position, score.Value, score.Key);
                    position++;
                }
            }
            else
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
        }
    }
}
