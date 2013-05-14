namespace BullsAndCows
{
    using System;
    using System.Text.RegularExpressions;

    public class GameEngine
    {
        private const int MaxHelpsCount = 5;
        private const int SecretNumberLength = 4;

        private readonly ScoreBoard scoreBoard;
        private readonly IPrinter consolePrinter;

        private Command currentCommand;
        private string secretNumber;
        private int attemptsCount;
        private int helpsCount;
        private bool exitFromGame;
        
        public GameEngine()
        {
            this.scoreBoard = new ScoreBoard();
            this.consolePrinter = new ConsolePrinter();
            this.exitFromGame = false;
        }

        public void Run()
        {
            this.StartNewGame();

            while (!this.exitFromGame)
            {
                this.ReadAction();
            }
        }

        private void StartNewGame()
        {
            this.consolePrinter.Clear();
            this.consolePrinter.PrintWelcomeMessage();

            this.secretNumber = "8130";// Generator.SecretNumber(SecretNumberLength);   
            this.attemptsCount = 0;
            this.helpsCount = 0;
        }

        private void ReadAction()
        {
            this.consolePrinter.PrintGuessOrCommandAskingMessage();
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
                            this.consolePrinter.PrintScoreBoard(this.scoreBoard);
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
                            this.exitFromGame = true;
                            break;
                        }
                }
            }
            else
            {
                this.consolePrinter.PrintWrongGuessOrCommandMessage();
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
            if (this.helpsCount >= MaxHelpsCount)
            {
                this.consolePrinter.PrintForbiddenHelpMessage();
                return;
            }

            this.helpsCount++;

            int helpIndex = Generator.HelpIndex();
            string helpNumber = Generator.HelpNumber(this.secretNumber, helpIndex);
            this.consolePrinter.PrintHelpNumberMessage(helpNumber);
            this.consolePrinter.PrintRemainingHelpsMessage(MaxHelpsCount, this.helpsCount);
        }

        private void ProcessGuess(string guessNumber)
        {
            this.attemptsCount++;

            if (guessNumber == this.secretNumber)
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

                this.consolePrinter.PrintFailedGuessMessage(bulls, cows);
            }
        }

        private void AddResultToScoreBoard()
        {
            this.consolePrinter.PrintResultMessage(this.attemptsCount);

            if (this.helpsCount > 0)
            {
                this.consolePrinter.PrintUnsavedResultMessage();
                Console.ReadLine();

                this.StartNewGame();
                return;
            }

            this.consolePrinter.PrintNicknameMessage();
            string nickname = Console.ReadLine();
            
            Player player = new Player(nickname, this.attemptsCount);
            scoreBoard.AddPlayer(player);
            this.consolePrinter.PrintScoreBoard(this.scoreBoard);
            Console.ReadLine();

            this.StartNewGame();
        }
    }
}
