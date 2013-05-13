namespace BullsAndCows
{
    using System;

    public class Player : IComparable<Player>
    {
        public string Name { get; private set; }

        public int Attemps { get; private set; }

        public Player(string name, int attemps)
        {
            this.Name = name;
            this.Attemps = attemps;
        }

        public override string ToString()
        {
            string output = string.Format("{0} --> {1} guesses", this.Name, this.Attemps);
            return output;
        }

        public int CompareTo(Player other)
        {
            return this.Attemps.CompareTo(other.Attemps);
        }
    }
}
