//-----------------------------------------------------------------------
// <copyright file="ScoreBoard.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// The class represents a ScoreBoard's info.
    /// </summary>
    public class ScoreBoard
    {
        public const int PlayersToShow = 5;

        private readonly List<Player> ranking = new List<Player>();
        private readonly ReadOnlyCollection<Player> rankingsReadonly; 

        // TODO: Documentation
        /// <summary>
        /// 
        /// </summary>
        public ScoreBoard()
        {
            this.rankingsReadonly = new ReadOnlyCollection<Player>(this.ranking);
        }

        // TODO: Documentation
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<Player> Ranking
        {
            get
            {
                return this.rankingsReadonly;
            }
        }

        /// <summary>
        /// Adds a player to the Score board.
        /// </summary>
        /// <param name="player">Player object.</param>
        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player", "Player cannot be null.");
            }

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
