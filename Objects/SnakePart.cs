using System;

namespace Snake.Objects
{
    public class SnakePart : Part{
        public SnakePart(int x, int y, ConsoleColor foreColor, ConsoleColor backColor, char SnakeCharacter)
        :base(x,y,foreColor,backColor,SnakeCharacter)
        {}

         public SnakePart(int x, int y,char SnakeCharacter)
        :this(x,y,ConsoleColor.Green,ConsoleColor.DarkGreen,SnakeCharacter)
        {}

        public SnakePart(int x, int y)
        :this(x,y,ConsoleColor.DarkYellow,ConsoleColor.Green,'*')
        {}

         public override void Paint()
        {
            Console.SetCursorPosition(this.X, this.Y);
            switch(PartCharacter)
            {
                case (char)2:
                    Console.BackgroundColor = ConsoleColor.Black; 
                    Console.ForegroundColor = ConsoleColor.Green; 
                    break;
                default:
                    Console.BackgroundColor = this.BackColor; 
                    Console.ForegroundColor = this.ForeColor; 
                    break;
            }
            Console.Write(PartCharacter);
        }
    }

}