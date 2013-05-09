using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class ScoreBoard
    {
        private const int PlayersToShow = 5;
        private readonly SortedList<int, string> ranking = new SortedList<int, string>();

        public ScoreBoard()
        {
        }

        public void Show()
        {
            if (this.ranking.Count() > 0)
            {
                Console.WriteLine("Scoreboard:");
                
                int position = 1;
                foreach (var player in this.ranking)
                {
                    if (position <= PlayersToShow)
                    {
                        Console.WriteLine("{0}. {1} --> {2} guesses", position, player.Value, player.Key);
                        position++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
        }

        public void AddPlayer(int score)
        {
            Console.WriteLine("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine().Trim();

            this.ranking.Add(score, name);
        }
    }
}
