namespace BullsAndCows
{
    using System;

    public class ConsolePrinter : IPrinter
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }

        public void PrintGuessOrCommandAskingMessage()
        {
            Console.WriteLine("Enter your guess or command: ");
        }

        public void PrintWrongGuessOrCommandMessage()
        {
            Console.WriteLine("Please enter a 4-digit number or");
            Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
        }

        public void PrintFailedGuessMessage(int bulls, int cows)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
        }

        public void PrintHelpNumberMessage(string helpNumber)
        {
            Console.WriteLine("The number looks like {0}.", helpNumber);
        }

        public void PrintRemainingHelpsMessage(int maxHelps, int usedHelps)
        {
            Console.WriteLine("You used {0} helps from {1} possible helps", usedHelps, maxHelps);
        }

        public void PrintForbiddenHelpMessage()
        {
            Console.WriteLine("You can't use more helps!");
        }

        public void PrintResultMessage(int score)
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", score);
        }

        public void PrintUnsavedResultMessage()
        {
            Console.WriteLine("You used cheat in this game to this you will not be added to the scoreboard.");
        }

        public void PrintNicknameMessage()
        {
            Console.WriteLine("Please, write your nickname, because you will be added to the scoreboard.");
        }

        public void PrintScoreBoard(ScoreBoard scoreBoard)
        {
            Console.WriteLine(scoreBoard);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
