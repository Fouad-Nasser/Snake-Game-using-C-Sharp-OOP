using System;
using Snake.Interfaces;
using System.IO;

namespace Snake.Objects
{
    public class Playground : IPaintable
    {
        private const char BorderCharacter = ' ';
        private string record = File.ReadAllText(@"..\..\..\record.txt");
        private const ConsoleColor scoreColor = ConsoleColor.Cyan;
        private const ConsoleColor BorderColor = ConsoleColor.DarkCyan;
        private readonly int leftBorder;
        private readonly int rightBorder;
        private readonly int upBorder;
        private readonly int downBoder;


        public int LeftBorder{
            get{
                return leftBorder;
            }
        }

        public int RightBorder{
            get{
                return rightBorder;
            }
        }
        public int UpBorder{
            get{
                return upBorder;
            }
        }
        public int DownBorder{
            get{
                return downBoder;
            }
        }

        public Playground(int leftBorder, int rightBorder, int upBorder, int downBoder)
        {
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.upBorder = upBorder;
            this.downBoder = downBoder;
        }


        public void Paint()
        {
            Console.ForegroundColor = scoreColor;
            Console.SetCursorPosition(this.leftBorder, this.upBorder - 2);
            Console.Write($"Score: 0");
            Console.SetCursorPosition(this.leftBorder + 40, this.upBorder - 2);
            Console.Write($"Record: {record}");
            for (var i = this.leftBorder; i <= this.rightBorder; i++)
            {
                Utilites.PaintPart(i, this.upBorder,BorderCharacter,backColor:BorderColor);
                Utilites.PaintPart(i, this.downBoder,BorderCharacter,backColor:BorderColor);
            }

            for (var i = this.upBorder; i <= this.downBoder; i++)
            {
               Utilites.PaintPart(this.leftBorder, i, BorderCharacter,backColor:BorderColor);
               Utilites.PaintPart(this.rightBorder, i,BorderCharacter,backColor:BorderColor);
            }

            PrintMsg("Press p to pause");
        }


        public void PrintMsg(string str)
        {
            Utilites.ConsoleDefaultColors();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(this.leftBorder, this.downBoder+2);
            Console.Write(str);
        }
    }
}