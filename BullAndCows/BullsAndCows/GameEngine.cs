//-----------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The class is used to simulate the game.
    /// </summary>
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
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        public GameEngine()
        {
            this.scoreBoard = new ScoreBoard();
            this.consolePrinter = new ConsolePrinter();
            this.secretNumber = Generator.SecretNumber(SecretNumberLength);   
            this.attemptsCount = 0;
            this.helpsCount = 0;
            this.exitFromGame = false;
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Run()
        {
            this.consolePrinter.PrintWelcomeMessage();

            while (!this.exitFromGame)
            {
                this.consolePrinter.PrintGuessOrCommandAskingMessage();
                string input = Console.ReadLine().Trim();
                this.ReadAction(input);
            }
        }

        private void ReadAction(string input)
        {
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

        private void StartNewGame()
        {
            this.consolePrinter.Clear();
            this.consolePrinter.PrintWelcomeMessage();

            this.secretNumber = Generator.SecretNumber(SecretNumberLength);   
            this.attemptsCount = 0;
            this.helpsCount = 0;
        } 

        private bool IsGuess(string input)
        {
            if (input == null || input.Length != SecretNumberLength)
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
                this.currentCommand = newCommand;
            }

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
                this.consolePrinter.PrintResultMessage(this.attemptsCount);

                if (this.helpsCount > 0)
                {
                    this.consolePrinter.PrintUnsavedResultMessage();
                    Console.ReadLine();

                    this.StartNewGame();
                    return;
                }

                this.consolePrinter.PrintNicknameMessage();
                string nickname = Console.ReadLine().Trim();
                this.AddResultToScoreBoard(nickname, this.attemptsCount);
                Console.ReadLine();

                this.StartNewGame();
            }
            else
            {
                int bulls = 0;
                int cows = 0;

                // Bull counter
                bool[] isBull = new bool[SecretNumberLength];
                for (int i = 0; i < SecretNumberLength; i++)
                {
                    if (this.secretNumber[i] == guessNumber[i])
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

        private void AddResultToScoreBoard(string nickname, int attempts)
        {
            Player player = new Player(nickname, attempts);
            this.scoreBoard.AddPlayer(player);
            this.consolePrinter.PrintScoreBoard(this.scoreBoard);
        }
    }
}
