//-----------------------------------------------------------------------
// <copyright file="BullsAndCows.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    /// <summary>
    /// Bulls and cows main class.
    /// </summary>
    public class BullsAndCows
    {
        /// <summary>
        /// Bulls and cows main method.
        /// </summary>
        public static void Main()
        {
            GameEngine game = new GameEngine();
            game.Run();
        }
    }
}
