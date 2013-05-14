namespace BullsAndCows
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// The class represents a ScoreBoard's info.
    /// </summary>
    public class ScoreBoard
    {
        private const int PlayersToShow = 5;
        private List<Player> ranking = new List<Player>();
        private ReadOnlyCollection<Player> rankingsReadonly;

        public ReadOnlyCollection<Player> Ranking
        {
            get
            {
                return this.rankingsReadonly;
            }
        }

        public ScoreBoard()
        {
            this.rankingsReadonly = new ReadOnlyCollection<Player>(this.ranking);
        }

        /// <summary>
        /// Adds a player to the Score board.
        /// </summary>
        /// <param name="player">Player object.</param>
        public void AddPlayer(Player player)
        {
            this.ranking.Add(player);
            this.SortRanking();
        }

        /// <summary>
        /// Gets the string representation of the Score board.
        /// </summary>
        /// <returns>String representation.</returns>
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
