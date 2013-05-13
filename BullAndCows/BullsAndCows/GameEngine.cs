using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class GameEngine
    {
        private int secretNumber;
        private bool usedCheat;
        private bool isGameOver;
        private int attemptsCount;
        private string helpCharecters;
        private ScoreBoard scoreBoard;
        private Command currentCommand;

        public GameEngine()
        {
            this.secretNumber = Generator.SecretNumber();
            this.usedCheat = false;
            this.isGameOver = false;
            this.attemptsCount = 1;
            this.helpCharecters = "XXXX";
            this.scoreBoard = new ScoreBoard();
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

        private void ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");
            string input = Console.ReadLine().Trim();

            if (this.IsGuess(input))
            {
                int guess = int.Parse(input);
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

            secretNumber = Generator.SecretNumber();
            usedCheat = false;
            isGameOver = false;
            attemptsCount = 1;
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

        private void PrintWelcomeSign()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
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

            string nickname = Console.ReadLine();
            Player player = new Player(nickname, this.attemptsCount);
            scoreBoard.AddPlayer(player);

            this.StartNewGame();
        }

        private void ProcessGuess(int guessValue)
        {
            if (guessValue == secretNumber)
            {
                FinishGame();
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
