using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCows.Test
{
    [TestClass]
    public class ConsolePrinterTests
    {
        [TestMethod]
        public void PrintWelcomeMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            try
            {
                message.PrintWelcomeMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintGuessOrCommandAskingMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            try
            {
                message.PrintWrongGuessOrCommandMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintWrongGuessOrCommandMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            try
            {
                message.PrintWrongGuessOrCommandMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintFailedGuessMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            int bulls = 3;
            int cows = 0;
            try
            {
                message.PrintFailedGuessMessage(bulls, cows);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintHelpNumberMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            string helpNumber="3";
            try
            {
                message.PrintHelpNumberMessage(helpNumber);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintRemainingHelpsMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            int maxHelps = 3;
            int usedHelps = 0;
            try
            {
                message.PrintRemainingHelpsMessage(maxHelps, usedHelps);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintForbiddenHelpMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
           
            try
            {
                message.PrintForbiddenHelpMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintResultMessageTest()
        {            
            ConsolePrinter message = new ConsolePrinter();
            int score = 6;
            try
            {
                message.PrintResultMessage(score);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintUnsavedResultMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            
            try
            {
                message.PrintUnsavedResultMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintNicknameMessageTest()
        {
            ConsolePrinter message = new ConsolePrinter();

            try
            {
                message.PrintNicknameMessage();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PrintScoreBoardTest()
        {
            ConsolePrinter message = new ConsolePrinter();
            ScoreBoard scoreBoard = new ScoreBoard(); 
            try
            {
                message.PrintScoreBoard(scoreBoard);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
            
    }
}
