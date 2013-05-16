namespace BullsAndCows
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The class is used to simulate the game.
    /// </summary>
    public class GameEngine
    {
        public const int MaxHelpsCount = 5;
        public const int SecretNumberLength = 4;

        public readonly ScoreBoard ScoreBoard;
        public readonly IPrinter ConsolePrinter;

        public Command CurrentCommand { get; private set; }
        public string SecretNumber { get; private set; }
        public int AttemptsCount { get; private set; }
        public int HelpsCount { get; private set; }
        public bool ExitFromGame { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of GameEngine class.
        /// </summary>
        public GameEngine()
        {
            this.ScoreBoard = new ScoreBoard();
            this.ConsolePrinter = new ConsolePrinter();
            this.SecretNumber = "8130";// Generator.SecretNumber(SecretNumberLength);   
            this.AttemptsCount = 0;
            this.HelpsCount = 0;
            this.ExitFromGame = false;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Run()
        {
            this.ConsolePrinter.PrintWelcomeMessage();

            while (!this.ExitFromGame)
            {
                this.ConsolePrinter.PrintGuessOrCommandAskingMessage();
                string input = Console.ReadLine().Trim();
                this.ReadAction(input);
            }
        }

        public void ReadAction(string input)
        {
            if (this.IsGuess(input))
            {
                string guess = input;
                this.ProcessGuess(guess);
            }
            else if (this.IsCommand(input))
            {
                switch (this.CurrentCommand)
                {
                    case Command.Top:
                        {
                            this.ConsolePrinter.PrintScoreBoard(this.ScoreBoard);
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
                            this.ExitFromGame = true;
                            break;
                        }
                }
            }
            else
            {
                this.ConsolePrinter.PrintWrongGuessOrCommandMessage();
            }
        }

        private void StartNewGame()
        {
            this.ConsolePrinter.Clear();
            this.ConsolePrinter.PrintWelcomeMessage();

            this.SecretNumber = "8130";// Generator.SecretNumber(SecretNumberLength);   
            this.AttemptsCount = 0;
            this.HelpsCount = 0;
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

            Command newCommand;
            bool isCommand = Enum.TryParse(uppedFirstChar, out newCommand);

            if (isCommand)
            {
                this.CurrentCommand = newCommand;
            }

            return isCommand;
        }

        private void Help()
        {
            if (this.HelpsCount >= MaxHelpsCount)
            {
                this.ConsolePrinter.PrintForbiddenHelpMessage();
                return;
            }

            this.HelpsCount++;

            int helpIndex = Generator.HelpIndex();
            string helpNumber = Generator.HelpNumber(this.SecretNumber, helpIndex);
            this.ConsolePrinter.PrintHelpNumberMessage(helpNumber);
            this.ConsolePrinter.PrintRemainingHelpsMessage(MaxHelpsCount, this.HelpsCount);
        }

        private void ProcessGuess(string guessNumber)
        {
            this.AttemptsCount++;

            if (guessNumber == this.SecretNumber)
            {
                this.AddResultToScoreBoard();
            }
            else
            {
                int bulls = 0;
                int cows = 0;

                // Bull counter
                bool[] isBull = new bool[SecretNumberLength];
                for (int i = 0; i < SecretNumberLength; i++)
                {
                    if (this.SecretNumber[i] == guessNumber[i])
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
                        if (!isBull[j] && !isCow[j] && (guessNumber[i] == this.SecretNumber[j]))
                        {
                            isCow[j] = true;
                            cows++;         
                            break;
                        }
                    }
                }

                this.ConsolePrinter.PrintFailedGuessMessage(bulls, cows);
            }
        }

        private void AddResultToScoreBoard()
        {
            this.ConsolePrinter.PrintResultMessage(this.AttemptsCount);

            if (this.HelpsCount > 0)
            {
                this.ConsolePrinter.PrintUnsavedResultMessage();
                Console.ReadLine();

                this.StartNewGame();
                return;
            }

            this.ConsolePrinter.PrintNicknameMessage();
            string nickname = Console.ReadLine();
            
            Player player = new Player(nickname, this.AttemptsCount);
            this.ScoreBoard.AddPlayer(player);
            this.ConsolePrinter.PrintScoreBoard(this.ScoreBoard);
            Console.ReadLine();

            this.StartNewGame();
        }
    }
}
