namespace BowlingGame.Core.Abstractions
{
    public interface IBowlingGame
    {
        void NewGame();
        void AddRoll(int pins);
        int Score(int frameIndex);
        int TotalScore { get; }
    }
}
