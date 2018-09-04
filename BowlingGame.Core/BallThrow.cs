using BowlingGame.Core.Abstractions;

namespace BowlingGame.Core
{
    public class BallThrow : IBallThrow
    {
        public BallThrow(int pins)
        {
            Pins = pins;
        }

        public int Pins { get; }
    }
}