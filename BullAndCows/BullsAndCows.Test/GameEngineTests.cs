namespace BullsAndCows.Test
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GameEngineConstructorTest()
        {
            GameEngine gameEngine = new GameEngine();
            int actualAttemptsCount = (int)typeof(GameEngine).GetField("attemptsCount", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            int actualHelpsCount = (int)typeof(GameEngine).GetField("helpsCount", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            bool actualExitFromGame = (bool)typeof(GameEngine).GetField("exitFromGame", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            Assert.AreEqual(0, actualAttemptsCount);
            Assert.AreEqual(0, actualHelpsCount);
            Assert.AreEqual(false, actualExitFromGame);
        }

        [TestMethod]
        public void ReadExitCommandTest()
        {
            GameEngine gameEngine = new GameEngine();
            typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "exit" });
            Command actual = (Command)typeof(GameEngine).GetField("currentCommand", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            Command expected = Command.Exit;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadRestartCommandTest()
        {
            GameEngine gameEngine = new GameEngine();
            typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "restart" });
            Command actual = (Command)typeof(GameEngine).GetField("currentCommand", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            Command expected = Command.Restart;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTopCommandTest()
        {
            GameEngine gameEngine = new GameEngine();
            typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "top" });
            Command actual = (Command)typeof(GameEngine).GetField("currentCommand", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            Command expected = Command.Top;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadHelpCommandTest()
        {
            GameEngine gameEngine = new GameEngine();
            typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "help" });
            Command actual = (Command)typeof(GameEngine).GetField("currentCommand", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
            Command expected = Command.Help;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadGuessTest_7725_2375()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "2375" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 1, 2, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadGuessTest_7725_8946()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "8946" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 0, 0, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadGuessTest_7725_1055()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "1055" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 1, 0, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadGuessTest_7725_2253()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "2253" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 0, 2, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadGuessTest_7725_7375()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "7375" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 2, 1, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadGuessTest_7725_2775()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetField("secretNumber", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(gameEngine, "7725");
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "2775" });
                string actual = sw.ToString();
                string expected = string.Format("Wrong number! Bulls: {0}, Cows: {1}{2}", 2, 2, Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ReadWrongGuessOrCommandTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "WRONGGGGGGG" });
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
        public void ReadNullGuessOrCommandTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();
                typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { null });
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
        public void ExecuteExitCommandTest()
        {
            using (StringReader sr = new StringReader("exit"))
            {
                GameEngine gameEngine = new GameEngine();
                Console.SetIn(sr);
                gameEngine.Run();
                bool actual = (bool)typeof(GameEngine).GetField("exitFromGame", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine);
                Assert.IsTrue(actual);
            }
        }

        [TestMethod]
        public void ForbiddenHelpTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GameEngine gameEngine = new GameEngine();

                int maxHelps = 5;
                for (int i = 1; i <= maxHelps + 1; i++)
                {
                    // Clears StringWriter
                    StringBuilder sb = sw.GetStringBuilder();
                    sb.Remove(0, sb.Length);
                    typeof(GameEngine).GetMethod("ReadAction", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "help" });
                }

                string actual = sw.ToString();
                string expected = string.Format("You can't use more helps!{0}", Environment.NewLine);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void AddResultToScoreBoardTest()
        {
            GameEngine gameEngine = new GameEngine();
            typeof(GameEngine).GetMethod("AddResultToScoreBoard", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(gameEngine, new object[] { "Pesho", 21 });
            var actual = (typeof(GameEngine).GetField("scoreBoard", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gameEngine) as ScoreBoard).Ranking[0];
            Player expected = new Player("Pesho", 21);
            Assert.IsTrue(expected.CompareTo(actual) == 0);
        }
    }
}
