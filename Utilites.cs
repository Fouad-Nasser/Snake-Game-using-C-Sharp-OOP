using System;

namespace Snake
{
    public static class Utilites
    {
        private static readonly Random Randomizer = new Random();
        private static readonly ConsoleColor ExitBackgroundColor = ConsoleColor.Black;
        private static readonly ConsoleColor ExitForegroungColor = ConsoleColor.White;


        public static int GenerateNumber(int min, int max)
        {
            return Randomizer.Next(min, max + 1);
        }

        public static void PaintPart(int x, int y, char c, ConsoleColor foreColor = ConsoleColor.White,
                                     ConsoleColor backColor = ConsoleColor.Black){
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = foreColor;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }


        public static void ConsoleDefaultColors()
        {
            Console.BackgroundColor = ExitBackgroundColor;
            Console.ForegroundColor = ExitForegroungColor;
        }
    }
}