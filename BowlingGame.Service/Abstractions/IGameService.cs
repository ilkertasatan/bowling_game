namespace BowlingGame.Service.Abstractions
{
    public interface IGameService
    {
        void StartNewGame();
        void AddRoll(int pins);
        int GetTotalScore();
        int GetFrameScoreByIndex(int frameIndex);
    }
}
