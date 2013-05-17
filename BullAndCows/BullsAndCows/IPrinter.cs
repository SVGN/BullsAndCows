//-----------------------------------------------------------------------
// <copyright file="IPrinter.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    /// <summary>
    /// The interface includes messages which will be used ingame.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints welcome message.
        /// </summary>
        void PrintWelcomeMessage();

        /// <summary>
        /// Asks for a command.
        /// </summary>
        void PrintGuessOrCommandAskingMessage();

        /// <summary>
        /// Wrong command message.
        /// </summary>
        void PrintWrongGuessOrCommandMessage();

        /// <summary>
        /// Prints a help message if the secret number is not guessed.
        /// </summary>
        /// <param name="bulls">Bulls count.</param>
        /// <param name="cows">Cows count.</param>
        void PrintFailedGuessMessage(int bulls, int cows);

        /// <summary>
        /// Prints a message, containing a single digit revealed.
        /// </summary>
        /// <param name="helpNumber">Number with one digit revealed.</param>
        void PrintHelpNumberMessage(string helpNumber);

        /// <summary>
        /// Prints how many times (of the max possible) the player revealed a digit.
        /// </summary>
        /// <param name="maxHelps">Max possible helps.</param>
        /// <param name="usedHelps">Actual helps.</param>
        void PrintRemainingHelpsMessage(int maxHelps, int usedHelps);

        /// <summary>
        /// Prints a message if the player tries to use help more than max possible times.
        /// </summary>
        void PrintForbiddenHelpMessage();

        /// <summary>
        /// Prints player's result, when he guessed the number.
        /// </summary>
        /// <param name="score">Player's result.</param>
        void PrintResultMessage(int score);

        /// <summary>
        /// Notifies the player that his score wont be added.
        /// </summary>
        void PrintUnsavedResultMessage();

        /// <summary>
        /// Asks the player for a nickname.
        /// </summary>
        void PrintNicknameMessage();

        /// <summary>
        /// Prints the Score board to the console.
        /// </summary>
        /// <param name="scoreBoard">ScoreBoard instance.</param>
        void PrintScoreBoard(ScoreBoard scoreBoard);

        /// <summary>
        /// Clears console.
        /// </summary>
        void Clear();
    }
}