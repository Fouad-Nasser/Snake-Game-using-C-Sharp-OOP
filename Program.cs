using System;

namespace Snake_Game_using_C_Sharp_OOP
{
    using Snake.Core;
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Engine.StartGame(4,25,2,60);
            }
            while(EndGame.NewGame);
        }
    }
}
