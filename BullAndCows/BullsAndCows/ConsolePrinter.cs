namespace BullsAndCows
{
    using System;

    /// <summary>
    /// This classed is used to print messages on the console.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Prints welcome message.
        /// </summary>
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");  
        }
        
           
        /// <summary>
        /// Asks for a command.
        /// </summary>
        public void PrintGuessOrCommandAskingMessage()
        {
            Console.WriteLine("Enter your guess or command: ");
        }

        /// <summary>
        /// Wrong command message.
        /// </summary>
        public void PrintWrongGuessOrCommandMessage()
        {
            Console.WriteLine("Please enter a 4-digit number or");
            Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
        }

        /// <summary>
        /// Prints a help message if the secret number is not guessed.
        /// </summary>
        /// <param name="bulls">Bulls count.</param>
        /// <param name="cows">Cows count.</param>
        public void PrintFailedGuessMessage(int bulls, int cows)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
        }

        /// <summary>
        /// Prints a message, containing a single digit revealed.
        /// </summary>
        /// <param name="helpNumber">Number with one digit revealed.</param>
        public void PrintHelpNumberMessage(string helpNumber)
        {
            Console.WriteLine("The number looks like {0}.", helpNumber);
        }

        /// <summary>
        /// Prints how many times (of the max possible) the player revealed a digit.
        /// </summary>
        /// <param name="maxHelps"></param>
        /// <param name="usedHelps"></param>
        public void PrintRemainingHelpsMessage(int maxHelps, int usedHelps)
        {
            Console.WriteLine("You used {0} helps from {1} possible helps", usedHelps, maxHelps);
        }

        /// <summary>
        /// Prints a message if the player tries to use help more than max possible times.
        /// </summary>
        public void PrintForbiddenHelpMessage()
        {
            Console.WriteLine("You can't use more helps!");
        }

        /// <summary>
        /// Prints player's result, when he guessed the number.
        /// </summary>
        /// <param name="score">Player's result.</param>
        public void PrintResultMessage(int score)
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", score);
        }

        /// <summary>
        /// Notifies the player that his score wont be added.
        /// </summary>
        public void PrintUnsavedResultMessage()
        {
            Console.WriteLine("You used cheat in this game to this you will not be added to the scoreboard.");
        }

        /// <summary>
        /// Asks the player for a nickname.
        /// </summary>
        public void PrintNicknameMessage()
        {
            Console.WriteLine("Please, write your nickname, because you will be added to the scoreboard.");
        }

        /// <summary>
        /// Prints the Score board to the console.
        /// </summary>
        /// <param name="scoreBoard"></param>
        public void PrintScoreBoard(ScoreBoard scoreBoard)
        {
            Console.WriteLine(scoreBoard);
        }

        /// <summary>
        /// Clears console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
