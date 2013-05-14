using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Test
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerConstructorTestName()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            Assert.AreEqual(player.Name, "Petar Ivanov");
        }
        [TestMethod]
        public void PlayerConstructorTestAttempts()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            Assert.AreEqual(player.Attempts, 6);
        }
        [TestMethod]
        public void PlayerToStringTest()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            string result = player.ToString();
            Assert.AreEqual(result, string.Format("{0} --> {1} guesses", name, attempts));
        }
        [TestMethod]
        public void PlayerCompareEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Ivan", 3);
            Assert.AreEqual(player1.CompareTo(player2), 0);
        }
        [TestMethod]
        public void PlayerCompareNamesNotEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Dragan", 3);
            Assert.AreNotEqual(player1.CompareTo(player2), 0);
        }
        [TestMethod]
        public void PlayerCompareAttemptsNotEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Ivan", 4);
            Assert.AreNotEqual(player1.CompareTo(player2), 0);
        }
    }
}
