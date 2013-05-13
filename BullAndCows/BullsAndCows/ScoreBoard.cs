using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class ScoreBoard
    {
        private const int PlayersToShow = 5;
        private readonly List<Player> ranking = new List<Player>();

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
                        Console.WriteLine("{0}. {1}",position, player);
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

        public void AddPlayer(Player player)
        {
            this.ranking.Add(player);
            this.SortRanking();
        }

        public void SortRanking()
        {
            this.ranking.Sort((x,y) => x.CompareTo(y));
        }
    }
}
