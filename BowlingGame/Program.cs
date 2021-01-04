using System;
using static Models.Enums.ThrowEnums;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Frames.ForEach(frame =>
            {
                game.CurrentFrameIndex = frame.Index;

                game.Throw(ThrowType.First);

                if (!frame.IsStrike || (game.IsFinalFrame && (frame.IsSpare || frame.IsStrike)))
                    game.Throw(ThrowType.Second);

                if (game.IsFinalFrame && (frame.IsSpare || frame.IsStrike))
                    game.Throw(ThrowType.Third);


            });
        }
    }
}
