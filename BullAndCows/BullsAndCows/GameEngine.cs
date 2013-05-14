using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class GameEngine
    {
        private const int SecretNumberLength = 4;
        private string secretNumber;
        private bool usedCheat;
        private bool isGameOver;
        private int attemptsCount;
        private string helpCharecters;
        private ScoreBoard scoreBoard;
        private Command currentCommand;

        public GameEngine()
        {
            this.secretNumber = "7725";//Generator.SecretNumber(SecretNumberLength);
            this.usedCheat = false;
            this.isGameOver = false;
            this.attemptsCount = 1;
            this.helpCharecters = "XXXX";
            this.scoreBoard = new ScoreBoard();
        }

        public void Run()
        {
            this.StartNewGame();

            while (!this.isGameOver)
            {
                this.ReadAction();
            }
        }

        private void StartNewGame()
        {
            this.PrintWelcomeSign();

            this.secretNumber = "8130";// Generator.SecretNumber(SecretNumberLength);
            this.usedCheat = false;
            this.isGameOver = false;
            this.attemptsCount = 1;
            this.helpCharecters = "XXXX";
        }

        private void ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");
            string input = Console.ReadLine().Trim();

            if (this.IsGuess(input))
            {
                string guess = input;
                this.ProcessGuess(guess);
            }
            else if (this.IsCommand(input))
            {
                switch (this.currentCommand)
                {
                    case Command.Top:
                        {
                            this.scoreBoard.Show();
                            break;
                        }

                    case Command.Restart:
                        {
                            this.StartNewGame();
                            break;
                        }

                    case Command.Help:
                        {
                            this.Help();
                            break;
                        }

                    case Command.Exit:
                        {
                            isGameOver = true;
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Please enter a 4-digit number or");
                Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
            }
        }

        private bool IsGuess(string input)
        {
            if (input == null || input.Length != 4)
            {
                return false;
            }

            Regex pattern = new Regex("[1-9][0-9][0-9][0-9]");
            return pattern.IsMatch(input);
        }

        private bool IsCommand(string input)
        {
            if (input == null || input.Length == 0)
            {
                return false;
            }

            string uppedFirstChar = string.Empty;
            if (char.IsLower(input[0]))
            {
                uppedFirstChar = char.ToUpper(input[0]).ToString() + input.Substring(1);
            }

            bool isCommand = Enum.TryParse(uppedFirstChar, out currentCommand);
            return isCommand;
        }

        private void Help()
        {
            this.usedCheat = true;

            if (helpCharecters.Contains('X'))
            {
                int i;
                do
                {
                    i = Generator.CheatIndex();
                }
                while (helpCharecters[i] != 'X');

                char[] newHelpCharecters = helpCharecters.ToCharArray();
                newHelpCharecters[i] = secretNumber.ToString()[i];
                helpCharecters = new string(newHelpCharecters);
            }

            Console.WriteLine("The number looks like {0}.", helpCharecters);
        }

        private void ProcessGuess(string guessNumber)
        {
            if (guessNumber == secretNumber)
            {
                FinishGame();
            }
            else
            {
                int bulls = 0;
                int cows = 0;

                // Bull counter
                bool[] isBull = new bool[SecretNumberLength];
                for (int i = 0; i < SecretNumberLength; i++)
                {
                    if (secretNumber[i] == guessNumber[i])
                    {
                        isBull[i] = true;
                        bulls++;
                    }
                }

                // Cow counter
                bool[] isCow = new bool[SecretNumberLength];
                for (int i = 0; i < SecretNumberLength; i++)
                {
                    for (int j = 0; j < SecretNumberLength; j++)
                    {
                        if (!isBull[j] && !isCow[j] && (guessNumber[i] == this.secretNumber[j]))
                        {
                            isCow[j] = true;
                            cows++;         
                            break;
                        }
                    }
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                this.attemptsCount++;
            }
        }

        private void FinishGame()
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attemptsCount);

            if (this.usedCheat)
            {
                Console.WriteLine("You used cheat in this game to this you will not be added to the scoreboard.");
                Console.ReadLine();
                this.StartNewGame();
                return;
            }

            Console.WriteLine("Please, write your nickname, because you will be added to the scoreboard.");
            string nickname = Console.ReadLine();
            
            Player player = new Player(nickname, this.attemptsCount);
            scoreBoard.AddPlayer(player);
            scoreBoard.Show();

            Console.ReadLine();
            this.StartNewGame();
        }

        private void PrintWelcomeSign()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }
    }
}
