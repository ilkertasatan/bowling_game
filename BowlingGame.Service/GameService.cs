using BowlingGame.Core.Abstractions;
using BowlingGame.Service.Abstractions;

namespace BowlingGame.Service
{
    public class GameService : IGameService
    {
        private readonly IBowlingGame _game = new Core.BowlingGame();

        public void StartNewGame()
        {
            this._game.NewGame();
        }

        public void AddRoll(int pins)
        {
            this._game.AddRoll(pins);
        }

        public int GetTotalScore()
        {
            return this._game.TotalScore;
        }

        public int GetFrameScoreByIndex(int frameIndex)
        {
            return this._game.Score(frameIndex);
        }
    }
}
