﻿namespace BullsAndCows.Test
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsolePrinterTests
    {
        private ConsolePrinter consolePrinter;

        [TestInitialize]
        public void TestInitialize()
        {
            this.consolePrinter = new ConsolePrinter();
        }

        [TestMethod]
        public void ConsolePrinterExceptionsTests()
        {
            try
            {
                this.consolePrinter.PrintWelcomeMessage();
                this.consolePrinter.PrintGuessOrCommandAskingMessage();
                this.consolePrinter.PrintWrongGuessOrCommandMessage();
                this.consolePrinter.PrintFailedGuessMessage(2, 3);
                this.consolePrinter.PrintHelpNumberMessage("X1X2");
                this.consolePrinter.PrintRemainingHelpsMessage(5, 3);
                this.consolePrinter.PrintForbiddenHelpMessage();
                this.consolePrinter.PrintResultMessage(19);
                this.consolePrinter.PrintUnsavedResultMessage();
                this.consolePrinter.PrintNicknameMessage();
                this.consolePrinter.PrintScoreBoard(new ScoreBoard());
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
                this.consolePrinter.PrintWelcomeMessage();
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
                this.consolePrinter.PrintGuessOrCommandAskingMessage();
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
                this.consolePrinter.PrintWrongGuessOrCommandMessage();
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
                this.consolePrinter.PrintFailedGuessMessage(2, 3);
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
                this.consolePrinter.PrintHelpNumberMessage("X12X");
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
                this.consolePrinter.PrintRemainingHelpsMessage(5, 3);
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
                this.consolePrinter.PrintForbiddenHelpMessage();
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
                this.consolePrinter.PrintResultMessage(25);
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
                this.consolePrinter.PrintUnsavedResultMessage();
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
                this.consolePrinter.PrintNicknameMessage();
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
                this.consolePrinter.PrintScoreBoard(scoreBoard);
                string actual = sw.ToString();
                string expected = string.Format("{0}{1}", scoreBoard.ToString(), Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        // [ExpectedException(typeof(IOException))]
        public void ConsolePrinterClearTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                this.consolePrinter.Clear();
                string actual = sw.ToString();
                string expected = string.Empty;
                Assert.AreEqual(expected, actual);
            }
        } 
    }
}
