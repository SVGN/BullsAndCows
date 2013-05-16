using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BullsAndCows.Test
{
    [TestClass]
    public class ConsolePrinterTests
    {
        private ConsolePrinter consolePrinter;

        [TestInitialize]
        public void TestInitialize()
        {
            consolePrinter = new ConsolePrinter();
        }

        [TestMethod]
        public void ConsolePrinterExceptionsTests()
        {
            try
            {
                consolePrinter.PrintWelcomeMessage();
                consolePrinter.PrintGuessOrCommandAskingMessage();
                consolePrinter.PrintWrongGuessOrCommandMessage();
                consolePrinter.PrintFailedGuessMessage(2, 3);
                consolePrinter.PrintHelpNumberMessage("X1X2");     
                consolePrinter.PrintRemainingHelpsMessage(5, 3);
                consolePrinter.PrintForbiddenHelpMessage();
                consolePrinter.PrintResultMessage(19);
                consolePrinter.PrintUnsavedResultMessage();
                consolePrinter.PrintNicknameMessage();
                consolePrinter.PrintScoreBoard(new ScoreBoard());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintWelcomeMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintWelcomeMessage();
                string actual = sw.ToString();
                string expected = string.Format("{0}{1}{2}{3}",
                    "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.",
                    Environment.NewLine,
                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.",
                    Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintGuessOrCommandAskingMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintGuessOrCommandAskingMessage();
                string actual = sw.ToString();
                string expected = string.Format("Enter your guess or command: {0}", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintWrongGuessOrCommandMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintWrongGuessOrCommandMessage();
                string actual = sw.ToString();
                string expected = string.Format("{0}{1}{2}{3}",
                    "Please enter a 4-digit number or",
                    Environment.NewLine,
                    "one of the commands: 'top', 'restart', 'help' or 'exit'.",
                    Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintFailedGuessMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintFailedGuessMessage(2, 3);
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 2, 3, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintHelpNumberMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintHelpNumberMessage("X12X");
                string actual = sw.ToString();
                string expected = string.Format("The number looks like {0}.{1}", "X12X", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintRemainingHelpsMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintRemainingHelpsMessage(5, 3);
                string actual = sw.ToString();
                string expected = string.Format("You used {0} helps from {1} possible helps{2}", 3, 5, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintForbiddenHelpMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintForbiddenHelpMessage();
                string actual = sw.ToString();
                string expected = string.Format("You can't use more helps!{0}", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintResultMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintResultMessage(25);
                string actual = sw.ToString();
                string expected = string.Format("Congratulations! You guessed the secret number in {0} attempts.{1}", 25, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintUnsavedResultMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintUnsavedResultMessage();
                string actual = sw.ToString();
                string expected = string.Format("You used cheat in this game to this you will not be added to the scoreboard.{0}", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintNicknameMessageTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintNicknameMessage();
                string actual = sw.ToString();
                string expected = string.Format("Please, write your nickname, because you will be added to the scoreboard.{0}", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void PrintScoreBoardTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(new Player("Ivan", 23));
            scoreBoard.AddPlayer(new Player("Georgi", 15));

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.PrintScoreBoard(scoreBoard);
                string actual = sw.ToString();
                string expected = string.Format("{0}{1}", scoreBoard.ToString(), Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ConsolePrinterClearTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consolePrinter.Clear();
                string actual = sw.ToString();
                string expected = string.Empty;
                Assert.AreEqual(expected, actual);
            }
        } 
    }
}
