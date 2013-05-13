namespace BullsAndCows
{
    using System;

    public static class Utils
    {
        public static int SecretNumberGenerator()
        {
            const int SecretNumberDigitsCount = 4;
            const int DigitsCount = 10;
            Random randomNumberGenerator = new Random();
            int secretNumber = 0;

            for (int i = 0; i < SecretNumberDigitsCount; i++)
            {
                int randomDigit = randomNumberGenerator.Next(0, DigitsCount);
                secretNumber += Math.Pow(DigitsCount, i) * randomDigit;
            }

            return secretNumber;
        }
    }
}
