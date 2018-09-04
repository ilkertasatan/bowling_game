namespace BowlingGame.Core.Abstractions
{
    public interface IScoreCalculator
    {
        void AddRoll(IBallThrow ballThrow);
        int FrameScore(int frameIndex);
    }
}
