using BowlingGame;
using System;
using Xunit;
using Shouldly;
using static Models.Enums.ThrowEnums;

namespace Tests
{
    public class Game_Input_Tests
    {
        [Fact]
        public void Game_Input_ShouldReturn_110()
        {
            Game game = new Game();

            //Frame 1 
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 4);
            game.Throw(ThrowType.Second, 3);


            //Frame 2
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 7);
            game.Throw(ThrowType.Second, 3);

            //Frame 3 
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 5);
            game.Throw(ThrowType.Second, 2);

            //Frame 4
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 8);
            game.Throw(ThrowType.Second, 1);

            //Frame 5
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 4);
            game.Throw(ThrowType.Second, 6);

            //Frame 6
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 2);
            game.Throw(ThrowType.Second, 4);

            //Frame 7
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 8);
            game.Throw(ThrowType.Second, 0);

            //Frame 8
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 8);
            game.Throw(ThrowType.Second, 0);

            //Frame 9
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 8);
            game.Throw(ThrowType.Second, 2);

            //Frame 10
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 1);
            game.Throw(ThrowType.Third, 7);


            game.UserScore.ShouldBe(110);
        }

        [Fact]
        public void Game_ShouldBePerfect_300()
        {
            Game game = new Game();

            //Frame 1 
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);


            //Frame 2
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 3 
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 4
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 5
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 6
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 7
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 8
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 9
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);

            //Frame 10
            ++game.CurrentFrameIndex;
            game.Throw(ThrowType.First, 10);
            game.Throw(ThrowType.Second, 10);
            game.Throw(ThrowType.Third, 10);


            game.UserScore.ShouldBe(300);
        }
    }
}
