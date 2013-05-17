//-----------------------------------------------------------------------
// <copyright file="Generator.cs" company="Team Osmium">
//     All rights reserved © Team Osmium 2013
// </copyright>
//-----------------------------------------------------------------------

namespace BullsAndCows
{
    using System;

    /// <summary>
    /// The class is used to generate values for fields of the game which require a random value.
    /// </summary>
    public static class Generator
    {
        private static readonly Random randomNumberGenerator = new Random();

        /// <summary>
        /// Generates a random number with a specific length.
        /// </summary>
        /// <param name="secretNumberLength">Length of the number.</param>
        /// <returns>Generated number.</returns>
        public static string SecretNumber(int secretNumberLength)
        {
            const int DigitsCount = 10;
            int secretNumber = 0;

            for (int i = 0; i < secretNumberLength; i++)
            {
                int randomDigit = randomNumberGenerator.Next(0, DigitsCount);
                secretNumber += (int)Math.Pow(DigitsCount, i) * randomDigit;
            }

            return secretNumber.ToString();
        }

        /// <summary>
        /// Generates a random index, which's value will be returned later.
        /// </summary>
        /// <returns>Generated index.</returns>
        public static int HelpIndex()
        {
            const int DigitsCount = 4;
            int cheatIndex = randomNumberGenerator.Next(0, DigitsCount);
            return cheatIndex;
        }

        /// <summary>
        /// Gets the secret number's digit at a specified position.
        /// </summary>
        /// <param name="SecretNumber">Secret number string value.</param>
        /// <param name="helpIndex">Position of the digit to show.</param>
        /// <returns>The digit's value at the specified position</returns>
        public static string HelpNumber(string secretNumber, int helpIndex)
        {
            if (helpIndex >= secretNumber.Length || helpIndex < 0)
            {
                throw new IndexOutOfRangeException("Help index is out of range");
            }

            const char HiddenDigits = 'X';
            char[] helpNumber = new char[secretNumber.Length];

            for (int i = 0; i < secretNumber.Length; i++)
            {
                if (helpIndex != i)
                {
                    helpNumber[i] = HiddenDigits;
                    continue;
                }

                helpNumber[i] = secretNumber[i];
            }

            return string.Join(string.Empty, helpNumber);
        }
    }
}
