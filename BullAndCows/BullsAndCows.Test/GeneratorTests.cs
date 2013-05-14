using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Test
{
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

            //We will check whether we have at least 2 different numbers in the array.
            bool hasDifferentNumbers = false;
            for (int i = 1; i < randomNumbers.Length; i++)
            {
                if (randomNumbers[0] != randomNumbers[i])
                    hasDifferentNumbers = true;
            }

            if (!hasDifferentNumbers)
                Assert.Fail("The generated numbers are not random.");                
        }
    }
}
