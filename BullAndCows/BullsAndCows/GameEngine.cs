using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class GameEngine
    {
        private readonly Random randomNumber;
        private int secretNumber;
        private bool canUseHelp;
        private int attemptsCount;
        private string helpCharecters;
        private ScoreBoard scoreBoard;

        public GameEngine()
        {
            randomNumber = new Random();
            this.secretNumber = randomNumber.Next(1000, 10000);
            this.canUseHelp = true;
            this.attemptsCount = 1;
            this.helpCharecters = "XXXX";
            scoreBoard = new ScoreBoard();
        }

        private bool ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");
            string line = Console.ReadLine().Trim();
            if(char.IsLower(line[0]))
            {
                line = char.ToUpper(line[0]).ToString() + line.Substring(1);
            }

            Regex patt = new Regex("[1-9][0-9][0-9][0-9]");
            Command command;
            bool isParsed = Enum.TryParse(line, out command);
            if (command != Command.Exit && command != Command.Help && 
                command != Command.Restart && command != Command.Top)
            {
                isParsed = false;
            }

            if (isParsed)
            {
                switch (command)
                {
                    case Command.Top:
                        scoreBoard.Show();
                        break;

                    case Command.Restart:
                        this.StartNewGame();
                        break;

                    case Command.Help:
                        this.Help();
                        break;

                    case Command.Exit:
                        return false;
                }
            }
            else if (patt.IsMatch(line))
            {
                int guess = int.Parse(line);
                this.ProcessGuess(guess);
            }
            else
            {
                Console.WriteLine("Please enter a 4-digit number or");
                Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
            }
            return true;
        }

        public void StartNewGame()
        {
            this.PrintWelcomeSign();
            while (this.ReadAction()) ;
        }

        private void Help()
        {
            this.canUseHelp = false;
            if (helpCharecters.Contains('X'))
            {
                int i;
                do
                {
                    i = this.randomNumber.Next(0, 4);
                }
                while (helpCharecters[i] != 'X');

                char[] newHelpCharecters = helpCharecters.ToCharArray();
                newHelpCharecters[i] = secretNumber.ToString()[i];
                helpCharecters = new string(newHelpCharecters);
            }
            Console.WriteLine("The number looks like {0}.", helpCharecters);
        }

        private void PrintWelcomeSign()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }

        private void ProcessWin()
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attemptsCount);
           
            if (this.canUseHelp)
            {
                scoreBoard.AddPlayer(this.attemptsCount);
            }

            StartNewGame();
        }

        private void ProcessGuess(int guessValue)
        {
            if (guessValue == secretNumber)
            {
                ProcessWin();
            }
            else
            {
                string secretNumString = secretNumber.ToString();
                int secretNumLength = secretNumString.Length;
                string guessNumString = guessValue.ToString();
                bool[] isBull = new bool[secretNumLength];
                int bulls = 0;
                int cows = 0;

                for (int i = 0; i < secretNumLength; i++)
                {
                    if (isBull[i] = secretNumString[i] == guessNumString[i])
                    {
                        bulls++;
                    }
                }

                int[] digits = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    digits[i] = 0;
                }

                for (int i = 0; i < secretNumLength; i++)
                {
                    if (!isBull[i])
                    {
                        digits[secretNumString[i] - '0']++;
                    }
                }

                for (int i = 0; i < secretNumLength; i++)
                {
                    if (!isBull[i])
                    {
                        if (digits[guessNumString[i] - '0'] > 0)
                        {
                            cows++;
                            digits[guessNumString[i] - '0']--;
                        }
                    }
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                attemptsCount++;
            }
        }

    }
}
