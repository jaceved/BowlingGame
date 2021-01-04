using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Models.Enums.ThrowEnums;

namespace Models
{
    public class Frame
    {
        public int Index { get; set; }
        public int PinsLeft { get; set; } = 10;

        public int FirstThrow { get; set; } = 0;
        public int SecondThrow { get; set; } = 0;
        public int ThirdThrow { get; set; } = 0;

        public bool IsStrike
        {
            get
            {
                return FirstThrow == 10;
            }
            set
            {
                IsStrike = value;
            }
        }
        public bool IsSpare
        {
            get
            {

                return (FirstThrow + SecondThrow) == 10 && FirstThrow != 10;
            }
            set
            {
                IsSpare = value;
            }
        }


        public int FrameScored { get; set; } = 0;

        public void ComputePinsLeft(int pinsKnockedDown)
        {
            if (pinsKnockedDown >= PinsLeft)
            {
                PinsLeft = 0;
            }
            else
            {
                PinsLeft -= pinsKnockedDown;
            }
        }

        public void HandleThrow(ThrowType throwType, int pinsHit)
        {
            switch (throwType)
            {
                case ThrowType.First:
                    FirstThrow += pinsHit;
                    ComputePinsLeft(pinsHit);
                    break;
                case ThrowType.Second:
                    SecondThrow += pinsHit;
                    ComputePinsLeft(pinsHit);
                    break;
                case ThrowType.Third:
                    ThirdThrow = pinsHit;
                    ComputePinsLeft(pinsHit);
                    break;
            }
        }

    }
}
