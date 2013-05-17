namespace BullsAndCows.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void SecretNumberTest()
        {
            string[] randomNumbers = new string[10];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = Generator.SecretNumber(4);
            }

            // We will check whether we have at least 2 different numbers in the array.
            bool hasDifferentNumbers = false;
            for (int i = 1; i < randomNumbers.Length; i++)
            {
                if (randomNumbers[0] != randomNumbers[i])
                {
                    hasDifferentNumbers = true;
                }
            }

            if (!hasDifferentNumbers)
            {
                Assert.Fail("The generated numbers are not random.");
            }
        }

        [TestMethod]
        public void HelpIndexTest()
        {
            int[] indexes = new int[10];

            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = Generator.HelpIndex();
            }

            // We will check whether we have at least 2 different indexes in the array.
            bool hasDifferentIndexes = false;
            for (int i = 1; i < indexes.Length; i++)
            {
                if (indexes[0] != indexes[i])
                {
                    hasDifferentIndexes = true;
                }
            }

            if (!hasDifferentIndexes)
            {
                Assert.Fail("The generated indexes are not random.");
            }
        }

        [TestMethod]
        public void HelpNumberTest()
        {
            string secretNumber = "1234";
            int helpIndex = 2;
            string result = Generator.HelpNumber(secretNumber, helpIndex);

            Assert.AreEqual(result[helpIndex], '3');
            Assert.AreNotEqual(result[helpIndex], 'X');
            Assert.AreEqual(result, "XX3X");
        }

        [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
        public void HelpNumberOutOfRangeTest()
        {
            string secretNumber = "1234";
            int helpIndex = 4;
            string result = Generator.HelpNumber(secretNumber, helpIndex);
        }
    }
}
