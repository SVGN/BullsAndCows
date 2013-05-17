//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    /// <summary>
    /// Enumeration of valid ingame Commands.
    /// </summary>
    public enum Command
    {
        /// <summary>
        /// Show Top 5 players on the Scoreboard.
        /// </summary>
        Top, 

        /// <summary>
        /// Restart the game.
        /// </summary>
        Restart, 
        
        /// <summary>
        /// Get help ingame.
        /// </summary>
        Help, 

        /// <summary>
        /// Exit game.
        /// </summary>
        Exit
    }
}
