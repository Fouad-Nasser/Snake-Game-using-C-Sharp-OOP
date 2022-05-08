using System;
using System.Threading;
using Objects.Menu;
using System.Collections.Generic;
using System.Drawing;


namespace Snake.Core
{
    using Enum;
    using Objects;
    public class Engine
    {
        private readonly Playground playground;
        private readonly Snake snake;
        private readonly FoodPart food;
        private bool isGameOver;

        public Engine(int PlaygroundBorderUp,int PlaygroundBorderDown,
        int PlaygroundBorderLeft, int PlaygroundBorderRight)
        {
            this.playground = new Playground(PlaygroundBorderLeft,
                PlaygroundBorderRight,
                PlaygroundBorderUp,
                PlaygroundBorderDown);
            this.snake = new Snake(PlaygroundBorderLeft,
                PlaygroundBorderRight,
                PlaygroundBorderUp,
                PlaygroundBorderDown);
            this.food = new FoodPart(PlaygroundBorderLeft,
                PlaygroundBorderRight,
                PlaygroundBorderUp,
                PlaygroundBorderDown);
            this.isGameOver = false;
        }

        private void m_PressEnter(object sender,MenuEvenrArgs e)
        {
            switch (e.Current)
            {
                case 0:
                    e.IsChoice = true;
                    Console.Clear();
                    snake.GameType = "Opend Border";
                    break;
                case 1:
                    e.IsChoice = true;
                    Console.Clear();
                    snake.GameType = "Closed Border";
                    break;
                case 2:
                    System.Environment.Exit(-1);
                    break;
            }
        }

        public void ShowMenu()
        {
            Menu m;
            List<string> items;
            items = new List<string>();
            items.Add("Opend Border");
            items.Add("Closed Border");
            items.Add("Exit");

            m = new Menu(items, ConsoleColor.DarkCyan, ConsoleColor.White,2,10);
            m.PressEnter += m_PressEnter;
            m.show();
        }
    }
}