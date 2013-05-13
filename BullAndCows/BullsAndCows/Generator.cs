namespace BullsAndCows
{
    using System;

    public static class Generator
    {
        public static int SecretNumber()
        {
            const int SecretNumberDigitsCount = 4;
            const int DigitsCount = 10;
            Random randomNumberGenerator = new Random();
            int secretNumber = 0;

            for (int i = 0; i < SecretNumberDigitsCount; i++)
            {
                int randomDigit = randomNumberGenerator.Next(0, DigitsCount);
                secretNumber += (int)Math.Pow(DigitsCount, i) * randomDigit;
            }

            return secretNumber;
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
