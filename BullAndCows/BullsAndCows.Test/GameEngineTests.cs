using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace BullsAndCows.Test
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GameEngineConstructorTest()
        {
            GameEngine gameEngine = new GameEngine();
            Assert.AreEqual(0, gameEngine.AttemptsCount);
            Assert.AreEqual(0, gameEngine.HelpsCount);
            Assert.AreEqual(false, gameEngine.ExitFromGame);
        }

        [TestMethod]
        public void GameEngineExitCommandTest()
        {
            using (StringReader sr = new StringReader("exit"))
            {
                GameEngine gameEngine = new GameEngine();
                Console.SetIn(sr);
                gameEngine.Run();
                bool actual = gameEngine.ExitFromGame;
                Assert.IsTrue(actual);
            }
        }

        //[TestMethod]
        //public void GameEngineRestartCommandTest()
        //{
        //    using (StringReader sr = new StringReader("restart"))
        //    {
        //        GameEngine gameEngine = new GameEngine();
        //        Console.SetIn(sr);
        //        gameEngine.Run();
        //        int actualAttemptsCount = gameEngine.AttemptsCount;
        //        int actualHelpsCount = gameEngine.HelpsCount;
        //        Assert.AreEqual(0, actualAttemptsCount);
        //        Assert.AreEqual(0, actualAttemptsCount);
        //        Assert.AreEqual(false, gameEngine.ExitFromGame);
        //    }
        //}
    }
}
