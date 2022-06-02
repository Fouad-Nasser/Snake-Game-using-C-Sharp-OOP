using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using Objects.Menu;

namespace Snake.Core
{
    static class EndGame
    {
         public static bool NewGame{ get; set;}
        private static void ShowMenu()
        {
            Menu m;
            List<string> items;
            items = new List<string>();
            items.Add("Play Again");
            items.Add("End Game");
            

            m = new Menu(items, ConsoleColor.DarkCyan, ConsoleColor.White,2,10);
            m.PressEnter += m_PressEnter;
            m.show();
        }
        private static void m_PressEnter(object sender,MenuEvenrArgs e)
        {
            switch (e.Current)
            {
                case 0:
                    e.IsChoice = true;
                    Console.Clear();
                    NewGame = true;
                    break;
                case 1:
                    e.IsChoice = true;
                    System.Environment.Exit(-1);
                    break;
            }
        }

         public static void Exit(int score)
        {
            int prev =  int.Parse(File.ReadAllText(@"..\..\..\record.txt"));
            if (score>prev)
            {
                File.WriteAllText(@"..\..\..\record.txt",Convert.ToString(score));
            }
            Console.Clear();
            Utilites.ConsoleDefaultColors();
            Console.SetCursorPosition(2,0);
            Colorful.Console.WriteAscii("Game Over", Color.FromArgb(0,255,255));
            ShowMenu();
        }
    }
}