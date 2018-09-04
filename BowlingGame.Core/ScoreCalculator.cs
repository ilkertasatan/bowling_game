using BowlingGame.Core.Abstractions;

namespace BowlingGame.Core
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly int[] rolls = new int[21];
        private int currentIndex;
        private int currentRoll;

        public void AddRoll(IBallThrow ballThrow)
        {
            rolls[currentRoll++] = ballThrow.Pins;
        }

        public int FrameScore(int frameIndex)
        {
            var total = 0;

            currentIndex = 0;

            for (var i = 0; i < frameIndex; i++)
            {
                if (IsStrike)
                {
                    total += 10 + this.rolls[currentIndex + 1] +
                                  this.rolls[currentIndex + 2];
                    currentIndex += 1;
                }
                else if (IsSpare)
                {
                    total += 10 + this.rolls[currentIndex + 2];
                    currentIndex += 2;
                }
                else
                {
                    total += this.rolls[currentIndex ] + this.rolls[currentIndex + 1];
                    currentIndex += 2;
                }
            }

            return total;
        }

        private bool IsStrike => rolls[currentIndex] == 10;

        private bool IsSpare => rolls[currentIndex] + rolls[currentIndex + 1] == 10;
    }
}
