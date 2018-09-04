using BowlingGame.Core.Abstractions;

namespace BowlingGame.Core
{
    public class BowlingGame : IBowlingGame
    {
        private const int StrikePinNumber = 10;

        private readonly IScoreCalculator scoreCalculator = new ScoreCalculator();
        private int currentFrameIndex;
        private bool isFirstRoll = true;
        

        public void NewGame()
        {
            
        }

        public void AddRoll(int pins)
        {
            scoreCalculator.AddRoll(new BallThrow(pins));

            if (this.isFirstRoll && pins == StrikePinNumber || !this.isFirstRoll)
            {
                this.currentFrameIndex++;

                if (this.currentFrameIndex > 10)
                    this.currentFrameIndex = 10;
            }
            else
            {
                this.isFirstRoll = false;
            }
        }

        public int Score(int frameIndex)
        {
            return scoreCalculator.FrameScore(frameIndex);
        }

        public int TotalScore => this.Score(this.currentFrameIndex);
    }
}
