namespace BullsAndCows
{
    using System;

    /// <summary>
    /// The class represents a player's info.
    /// </summary>
    public class Player : IComparable<Player>
    {
        // TODO: Check documentation
        private string name;
        private int attempts;

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

        // TODO: Check documentation
        /// <summary>
        /// Gets the player's name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty!", "name");
                }

                this.name = value;
            }
        }

        // TODO: Check documentation
        /// <summary>
        /// Gets the player's guess attempts.
        /// </summary>
        public int Attempts
        {
            get
            {
                return this.attempts;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("attempts", "Player attempts cannot be less than 1!");
                }

                this.attempts = value;
            }
        }

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
        /// <returns>Compare in attemts and then in name.</returns>
        public int CompareTo(Player other)
        {
            // Ascending order
            int compareInAttempts = -this.Attempts.CompareTo(other.Attempts);
            int compareInName = -this.Name.CompareTo(other.Name);
            if (compareInAttempts == 0)
            {
                return compareInName;
            }

            return compareInAttempts;
        }
    }
}
