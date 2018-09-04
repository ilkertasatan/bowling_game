using Xunit;

namespace BowlingGame.Tests
{
    [Collection("BowlingGameTest")]
    public class GameTest
    {
        private readonly Core.BowlingGame game = new Core.BowlingGame();

        [Fact]
        public void GameScore_WhenNoThrows()
        {
            Assert.Equal(0, game.TotalScore);
        }

        [Fact]
        public void GameScore_AddRollThrow()
        {
            game.AddRoll(5);
            game.AddRoll(4);

            Assert.Equal(9, game.TotalScore);
        }

        [Fact]
        public void GameAndScore_ThrowsWithNoMarks()
        {
            game.AddRoll(3);
            game.AddRoll(2);
            game.AddRoll(5);
            game.AddRoll(4);

            Assert.Equal(14, game.TotalScore);
            Assert.Equal(5, game.Score(1));
            Assert.Equal(14, game.Score(2));
        }

        [Fact]
        public void GameAndScore_WithSingleSpare()
        {
            game.AddRoll(5);
            game.AddRoll(5);
            game.AddRoll(3);

            Assert.Equal(13, game.Score(1));
        }

        [Fact]
        public void GameAndScore_TwoFrame_AfterFirstSpare()
        {
            game.AddRoll(3);
            game.AddRoll(7);
            game.AddRoll(3);
            game.AddRoll(2);

            Assert.Equal(13, game.Score(1));
            Assert.Equal(18, game.TotalScore);
        }

        [Fact]
        public void GameAndScore_WithSingleStrike()
        {
            game.AddRoll(10);

            Assert.Equal(10, game.Score(1));
            Assert.Equal(10, game.TotalScore);
        }

        [Fact]
        public void GameAndScore_WithSingleStrikeOneFrame()
        {
            game.AddRoll(10);
            game.AddRoll(4);
            game.AddRoll(5);

            Assert.Equal(19, game.Score(1));
            Assert.Equal(28, game.TotalScore);
        }

        [Fact]
        public void GameScore_HundredPercentStrike()
        {
            for (var i = 0; i < 12; i++)
            {
                game.AddRoll(10);
            }

            Assert.Equal(300, game.TotalScore);
        }

        [Fact]
        public void GameScore_FailedStrike()
        {
            for (var i = 0; i < 10; i++)
            {
                game.AddRoll(0);
            }

            Assert.Equal(0, game.TotalScore);
        }

        [Fact]
        public void GameScore_BoundryCheckStrike()
        {
            for (var i = 0; i < 9; i++)
            {
                game.AddRoll(0);
            }

            game.AddRoll(4);
            game.AddRoll(4);
            game.AddRoll(10);

            Assert.Equal(18, game.TotalScore);
        }

        [Fact]
        public void GameScore_SimpleFormat()
        {
            game.AddRoll(1);
            game.AddRoll(0);
            game.AddRoll(1);
            game.AddRoll(0);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);

            Assert.Equal(8, game.TotalScore);
        }

        [Fact]
        public void GameScore_SimpleFormat_WithStrike()
        {
            game.AddRoll(10);
            game.AddRoll(1);
            game.AddRoll(0);
            game.AddRoll(10);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);
            game.AddRoll(1);

            Assert.Equal(28, game.TotalScore);
        }

        [Fact]
        public void GameScore_BoundryMissed()
        {
            for (var i = 0; i < 11; i++)
            {
                game.AddRoll(10);
            }

            game.AddRoll(9);

            Assert.Equal(299, game.TotalScore);
        }

        [Fact]
        public void GameScore_BoundrySpare()
        {
            for (var i = 0; i < 9; i++)
            {
                game.AddRoll(10);
            }

            game.AddRoll(5);
            game.AddRoll(5);
            game.AddRoll(1);

            Assert.Equal(266, game.TotalScore);
        }

        [Fact]
        public void GameScore_BoundryOpen()
        {
            for (var i = 0; i < 9; i++)
            {
                game.AddRoll(10);
            }

            game.AddRoll(2);
            game.AddRoll(2);
            Assert.Equal(250, game.TotalScore);
        }
    }
}

