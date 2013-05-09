using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    class Play
    {
        static int secretNumber;
        static bool useHelp;
        static int attempts;
        readonly static Random randomNumber = new Random();

        public static bool ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");
            string line = Console.ReadLine().Trim();
            Regex patt = new Regex("[1-9][0-9][0-9][0-9]");

            switch (line)
            {
                case "top":
                    ScoreBoard.DisplayTop();
                    break;

                case "restart":
                    StartNewGame();
                    break;

                case "help":
                    Help();
                    break;

                case "exit":
                    return false;

                default:
                    if (patt.IsMatch(line))
                    {
                        int guess = int.Parse(line);
                        ProcessGuess(guess);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 4-digit number or");
                        Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
                    }
                    break;
            }
            return true;
        }
        public static void StartNewGame()
        {
            PrintWelcomeSign();
            secretNumber = randomNumber.Next(1000, 10000);
            attempts = 1;
            useHelp = true;
            ch = "XXXX";
        }
        static string ch;

        static void Help()
        {
            useHelp = false;
            if (ch.Contains('X'))
            {
                int i;
                do
                {
                    i = randomNumber.Next(0, 4);
                }
                while (ch[i] != 'X');

                char[] cha = ch.ToCharArray();
                cha[i] = secretNumber.ToString()[i];
                ch = new string(cha);
            }
            Console.WriteLine("The number looks like {0}.", ch);
        }
        static void PrintWelcomeSign()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }

        static void ProcessWin()
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attempts);
            if (useHelp)
            {
                ScoreBoard.TryAddToScoreboard(attempts);
            }
            StartNewGame();
        }

        static void ProcessGuess(int guess)
        {
            if (guess == secretNumber)
            {
                ProcessWin();
            }
            else
            {
                string strSecretNum = secretNumber.ToString();
                Console.WriteLine(strSecretNum);
                int len = strSecretNum.Length;
                string strGuessNum = guess.ToString();
                bool[] isBull = new bool[len];
                int bulls = 0;
                int cows = 0;
                for (int i = 0; i < len; i++)
                {
                    if (isBull[i] = strSecretNum[i] == strGuessNum[i])
                    {
                        bulls++;
                    }
                }
                int[] digs = new int[10];
                for (int d = 0; d < 10; d++)
                {
                    digs[d] = 0;
                }
                for (int i = 0; i < len; i++)
                {
                    if (!isBull[i])
                    {
                        digs[strSecretNum[i] - '0']++;
                    }
                }
                for (int i = 0; i < len; i++)
                {
                    if (!isBull[i])
                    {
                        if (digs[strGuessNum[i] - '0'] > 0)
                        {
                            cows++;
                            digs[strGuessNum[i] - '0']--;
                        }
                    }
                }
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                attempts++;
            }
        }

    }
}
