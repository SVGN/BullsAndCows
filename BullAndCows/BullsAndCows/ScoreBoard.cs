namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ScoreBoard
    {
        private const int PlayersToShow = 5;
        private readonly List<Player> ranking = new List<Player>();

        public void AddPlayer(Player player)
        {
            this.ranking.Add(player);
            this.SortRanking();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this.ranking.Count > 0)
            {
                output.AppendLine("Scoreboard:");
                
                int position = 1;
                foreach (var player in this.ranking)
                {
                    if (position <= PlayersToShow)
                    {
                        output.AppendFormat("{0}. {1}\n", position, player);
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
                output.AppendLine("Top scoreboard is empty.");
            }

            return output.ToString();
        }

        private void SortRanking()
        {
            this.ranking.Sort((x, y) => x.CompareTo(y));
        }
    }
}
