namespace BullsAndCows
{
    using System;

    public static class Generator
    {
        public static string SecretNumber(int secretNumberCount)
        {
            const int DigitsCount = 10;
            Random randomNumberGenerator = new Random();
            int secretNumber = 0;

            for (int i = 0; i < secretNumberCount; i++)
            {
                int randomDigit = randomNumberGenerator.Next(0, DigitsCount);
                secretNumber += (int)Math.Pow(DigitsCount, i) * randomDigit;
            }

            return secretNumber.ToString();
        }

        public static int CheatIndex()
        {
            const int DigitsCount = 4;
            Random randomNumberGenerator = new Random();
            int cheatIndex = randomNumberGenerator.Next(0, DigitsCount);
            return cheatIndex;
        }
    }
}
