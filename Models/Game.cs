using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Models.Enums.ThrowEnums;

namespace BowlingGame
{
    public class Game
    {
        public int Turkey = 30; // ignore for now..
        public int Streak = 0; // do we need to keep track of strike streaks? 
        public int MaxFrames = 10;
        public List<Frame> Frames { get; set; }
        public int CurrentFrameIndex { get; set; } = 0;
        public int UserScore { get; set; }

        public bool IsFinalFrame
        {
            get
            {
                return (CurrentFrameIndex == MaxFrames);
            }

        }

        public Game()
        {
            Init();
        }

        private void Init()
        {
            Frames = new List<Frame>();

            for (int i = 1; i <= MaxFrames; i++)
            {
                Frames.Add(new Frame() { Index = i });
            }
        }


        private Frame GetPreviousFrame()
        {
            var frm = Frames
                .SingleOrDefault(x => x.Index == (CurrentFrameIndex - 1));

            if (frm == null) return null;

            return frm;
        }

        private Frame GetFrame(int Index)
        {
            var frm = Frames
                .SingleOrDefault(x => x.Index == Index);

            if (frm == null) return null;

            return frm;
        }


        public void Throw(ThrowType throwType, int pinsHit = -1)
        {
            var frame = GetFrame(CurrentFrameIndex);
            Console.WriteLine($"Frame - {frame.Index}, {Enum.GetName(typeof(ThrowType), throwType) } throw \n (type a number):  ");
            int userInput;

            if (pinsHit >= 0)
                userInput = pinsHit;
            else
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine($"You entered an incorrect value. Try again..");
                    Throw(throwType);
                }
            }


            if (IsFinalFrame && (frame.IsSpare || frame.IsStrike))
            {
                frame.PinsLeft = 10;
            }

            if (userInput >= frame.PinsLeft)
            {
                userInput = frame.PinsLeft;
            }

            frame.HandleThrow(throwType, userInput);

            if (
                    frame.IsStrike
                ||
                    (throwType == ThrowType.Second && !(IsFinalFrame && (frame.IsSpare || frame.IsStrike)))
                ||
                    throwType == ThrowType.Third
                )
            {
                ComputeScore(frame);
            }

        }

        private void ComputeScore(Frame frame)
        {
            var previousFrame = GetPreviousFrame();


            UpdateCurrentFrameScore(frame);
            if (previousFrame == null)
            {
                //do not calculate the score if it's the first throw..
                return;
            }

            if (previousFrame.IsSpare)
            {
                previousFrame.FrameScored += (frame.FirstThrow + 10);

            }
            else if (previousFrame.IsStrike)
            {
                if (!frame.IsStrike)
                    previousFrame.FrameScored += (frame.FirstThrow + frame.SecondThrow + 10);
                else
                {
                    //TODO: Handle condition where user has scored multiple strikes in a row... how do we update frames??
                    //get last second previous frame
                    //var SecondPreviousFrame = GetFrame(CurrentFrameIndex - 2);

                    //if(SecondPreviousFrame != null)
                    //{
                    //    if (SecondPreviousFrame.IsStrike)
                    //    {
                    //        SecondPreviousFrame.FrameScored = Turkey;
                    //    }
                    //    else
                    //    {
                    //        //SecondPreviousFrame += (10 + 10 + )
                    //    }
                    //} 

                }

            }
            if (IsFinalFrame)
            {
                frame.FrameScored += frame.FirstThrow + frame.SecondThrow + frame.ThirdThrow;
            }
            UserScore = Frames.Sum(f => f.FrameScored);

            Console.WriteLine($"Current Score: {UserScore}");

        }


        private void UpdateCurrentFrameScore(Frame frame)
        {
            if (!frame.IsStrike && !frame.IsSpare)
            {
                Streak = 0;
                frame.FrameScored += (frame.FirstThrow + frame.SecondThrow);
            }
            else
            {
                Streak++;
            }
        }

    }
}
