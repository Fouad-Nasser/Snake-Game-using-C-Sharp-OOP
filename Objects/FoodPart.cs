using System;

namespace Snake.Objects
{
    public class FoodPart : Part
    {
        private readonly int leftBorder;
        private readonly int rightBorder;
        private readonly int upBorder;
        private readonly int downBorder;
       
        public FoodPart(int leftBorder, int rightBorder, int upBorder, int downBorder,
                        int x ,int y, ConsoleColor foreColor,ConsoleColor backColor,char partCharacter)
            : base(x, y, foreColor,backColor,partCharacter)
        {
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.upBorder = upBorder;
            this.downBorder = downBorder;
        }
        
        public FoodPart(int leftBorder, int rightBorder, int upBorder, int downBorder)
            : this(leftBorder, rightBorder, upBorder, downBorder,
                     0,0,ConsoleColor.Red,ConsoleColor.Black,(char)3)
        {
        }

        public override void Paint()
        {
            this.X = Utilites.GenerateNumber(this.leftBorder + 1, this.rightBorder - 1);
            this.Y = Utilites.GenerateNumber(this.upBorder + 1, this.downBorder - 1);
            Console.SetCursorPosition(this.X, this.Y);
            Console.BackgroundColor = this.BackColor;
            Console.ForegroundColor = this.ForeColor;
            Console.Write(this.PartCharacter);
        }
    }
}