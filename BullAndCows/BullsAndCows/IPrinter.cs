namespace BullsAndCows
{
    /// <summary>
    /// The interface includes messages which will be used ingame.
    /// </summary>
    public interface IPrinter
    {
        void PrintWelcomeMessage();

        void PrintGuessOrCommandAskingMessage();

        void PrintWrongGuessOrCommandMessage();

        void PrintFailedGuessMessage(int bulls, int cows);

        void PrintHelpNumberMessage(string helpNumber);
        
        void PrintRemainingHelpsMessage(int maxHelps, int usedHelps);

        void PrintForbiddenHelpMessage();

        void PrintResultMessage(int score);

        void PrintUnsavedResultMessage();

        void PrintNicknameMessage();

        void PrintScoreBoard(ScoreBoard scoreBoard);

        void Clear();
    }
}