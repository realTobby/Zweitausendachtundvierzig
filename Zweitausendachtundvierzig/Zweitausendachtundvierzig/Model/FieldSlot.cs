using System;
using System.Collections.Generic;
using System.Text;

namespace Zweitausendachtundvierzig.Model
{
    public enum FieldSlotOccupation
    {
        Empty = 0,
        Two = 2,
        Four = 4,
        Eight = 8,
        Sixteen = 16,
        ThirtyTwo = 32,
        SixtyFour = 64,
        OneHundredTwentyEight = 128,
        TwoHundredFiftySix = 256,
        FiveHundredTwelve = 512,
        OneThousandTwentyFour = 1024,
        TwoThousandFortyEight = 2048
    }

    public class FieldSlot
    {
        FieldSlotOccupation slotState;

        private int fieldPositionX = 0;
        private int fieldPositionY = 0;

        private int slotValue = 0;

        public int GetSlotValue()
        {
            return slotValue;
        }

        public int GetPositionX()
        {
            return fieldPositionX;
        }

        public int GetPositionY()
        {
            return fieldPositionY;
        }


        public FieldSlot(int x, int y)
        {
            slotState = FieldSlotOccupation.Empty;

            fieldPositionX = x;
            fieldPositionY = y;
        }

        public FieldSlotOccupation GetFieldState()
        {
            return slotState;
        }

        public void Init()
        {
            slotValue = 2;
            slotState = FieldSlotOccupation.Two;
        }

    }
}
