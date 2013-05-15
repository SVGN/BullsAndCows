using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace BullsAndCows.Test
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void ScoreBoardConstructorTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.IsNotNull(scoreBoard.Ranking);
        }

        [TestMethod]
        public void AddSinglePlayerTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            string name = "Pesho";
            int attempts = 20;
            scoreBoard.AddPlayer(new Player(name, attempts));
            Assert.IsTrue(scoreBoard.Ranking.Count == 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void AddNullPlayerTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(null);
        }

        [TestMethod]
        public void AddMultiplePlayersTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            string name = "Pesho";
            int attempts = 20;
            int playersCount = 10;
            for (int i = 0; i < playersCount; i++)
            {
                scoreBoard.AddPlayer(new Player(name, attempts));
            }

            Assert.IsTrue(scoreBoard.Ranking.Count == playersCount);
        }

        [TestMethod]
        public void RankingSortCorrectnessTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(new Player("Pesho", 3));
            scoreBoard.AddPlayer(new Player("Gosho", 5));
            scoreBoard.AddPlayer(new Player("Stamat", 1));
            scoreBoard.AddPlayer(new Player("Niki", 3));
            scoreBoard.AddPlayer(new Player("Anton", 1));

            bool areSorted = true;
            for (int i = 0; i < scoreBoard.Ranking.Count - 1; i++)
            {
                if (scoreBoard.Ranking[i].CompareTo(scoreBoard.Ranking[i + 1]) > 0)
                {
                    areSorted = false;
                }
            }

            Assert.IsTrue(areSorted);
        }

        [TestMethod]
        public void ScoreBoardToStringTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            string name = "Pesho";
            int attempts = 20;
            int playersCount = 10;
            for (int i = 0; i < playersCount; i++)
            {
                scoreBoard.AddPlayer(new Player(name, attempts));
            }

            StringBuilder output = new StringBuilder();

            if (scoreBoard.Ranking.Count > 0)
            {
                output.AppendLine("Scoreboard:");
            }
            else
            {
                output.AppendLine("Top scoreboard is empty.");
            }

            for (int i = 0; i < ScoreBoard.PlayersToShow && i < scoreBoard.Ranking.Count; i++)
            {
                output.AppendFormat("{0}. {1}\n", i + 1, scoreBoard.Ranking[i]);
            }

            Assert.IsTrue(scoreBoard.ToString() == output.ToString());
        }
    }
}
