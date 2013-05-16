using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Test
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerNullNameTest()
        {
            Player player = new Player(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerEmptyNameTest()
        {
            Player player = new Player(string.Empty, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerWhitespaceNameTest()
        {
            Player player = new Player("    ", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerZeroAttemptsTest()
        {
            Player player = new Player("Petar Ivanov", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerNegativeAttemptsTest()
        {
            Player player = new Player("Petar Ivanov", -5);
        }

        [TestMethod]
        public void PlayerConstructorTestName()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            string actual = player.Name;
            string expected = name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerConstructorTestAttempts()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            int actual = player.Attempts;
            int expected = attempts;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerNameSetterTest()
        {
            Player player = new Player("Ivan", 19);
            typeof(Player).GetProperty("Name").SetValue(player, "Gosho");
            string actual = player.Name;
            string expected = "Gosho";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerToStringTest()
        {
            string name = "Petar Ivanov";
            int attempts = 6;
            Player player = new Player(name, attempts);
            string actual = player.ToString();
            string expected = string.Format("{0} --> {1} guesses", name, attempts);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerCompareEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Ivan", 3);
            Assert.AreEqual(0, player1.CompareTo(player2));
        }

        [TestMethod]
        public void PlayerCompareNamesNotEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Dragan", 3);
            Assert.AreNotEqual(0, player1.CompareTo(player2));
        }

        [TestMethod]
        public void PlayerCompareAttemptsNotEqualTest()
        {
            Player player1 = new Player("Ivan", 3);
            Player player2 = new Player("Ivan", 4);
            Assert.AreNotEqual(0, player1.CompareTo(player2));
        }

        [TestMethod]
        public void PlayerCompareFirstPlayerIsWithHighScore()
        {
            Player player1 = new Player("Ivan", 2);
            Player player2 = new Player("Dragan", 3);
            Assert.IsTrue(player1.CompareTo(player2) > 0);
        }

        [TestMethod]
        public void PlayerCompareSecondPlayerIsWithHighScore()
        {
            Player player1 = new Player("Ivan", 6);
            Player player2 = new Player("Dragan", 3);
            Assert.IsTrue(player1.CompareTo(player2) < 0);
        }
    }
}
