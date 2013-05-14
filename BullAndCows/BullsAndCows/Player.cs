namespace BullsAndCows
{
    using System;

    /// <summary>
    /// The class represents a player's info.
    /// </summary>
    public class Player : IComparable<Player>
    {
        /// <summary>
        /// Initializes a new instance of Player class.
        /// </summary>
        /// <param name="name">Player's name.</param>
        /// <param name="attemps">Player's attempts to guess the secret number.</param>
        public Player(string name, int attemps)
        {
            this.Name = name;
            this.Attempts = attemps;
        }

        /// <summary>
        /// Gets the player's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the player's guess attempts.
        /// </summary>
        public int Attempts { get; private set; }

        /// <summary>
        /// String representation of the player.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            string output = string.Format("{0} --> {1} guesses", this.Name, this.Attempts);
            return output;
        }

        /// <summary>
        /// Compares this player to an other one.
        /// </summary>
        /// <param name="other">Other player.</param>
        /// <returns>Compare in attemts, then in name and then in hashcode.</returns>
        public int CompareTo(Player other)
        {
            int compareInAttempts = this.Attempts.CompareTo(other.Attempts);
            int compareInName = this.Name.CompareTo(other.Name);
            if (compareInAttempts == 0)
            {
                return compareInName;
            }

            return compareInAttempts;
        }
    }
}
