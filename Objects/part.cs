using System;
using Snake.Interfaces;

namespace Snake.Objects
{
    public abstract class Part:IPostionable,IPaintable
    {        
        public char PartCharacter
        {
            get;
            set;
        }
        public ConsoleColor ForeColor
        {
            get;
            set;
        }

        public ConsoleColor BackColor
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

         protected Part(int x, int y, ConsoleColor foreColor, ConsoleColor backColor, char partCharacter)
        {
            this.X = x;
            this.Y = y;
            this.ForeColor = foreColor;
            this.BackColor = backColor;
            this.PartCharacter = partCharacter;
        }

        protected Part():this(0,0,ConsoleColor.White,ConsoleColor.Black,default(char)){
                
        }

        public abstract void Paint(); 
    }
}