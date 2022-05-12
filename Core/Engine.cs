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

        private void CheckKey()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if ((this.snake.Direction == Direction.Left) || (this.snake.Direction == Direction.Right))
                        {
                            this.snake.Direction = Direction.Up;
                        }

                        return;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if ((this.snake.Direction == Direction.Left) || (this.snake.Direction == Direction.Right))
                        {
                            this.snake.Direction = Direction.Down;
                        }

                        return;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if ((this.snake.Direction == Direction.Up) || (this.snake.Direction == Direction.Down))
                        {
                            this.snake.Direction = Direction.Left;
                        }

                        return;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if ((this.snake.Direction == Direction.Up) || (this.snake.Direction == Direction.Down))
                        {
                            this.snake.Direction = Direction.Right;
                        }
                        return;
                    case ConsoleKey.P:
                       playground.PrintMsg("press any key to continue...");
                        Console.ReadKey();
                       playground.PrintMsg("Press p to pause              ");
                       return;
                }
            }
        }

         public void Run()
        {
            this.playground.Paint();
            this.food.Paint();
            while (!this.isGameOver)
            {
                this.CheckKey();
                this.snake.Move();
                this.snake.CheckBiteItself(ref this.isGameOver);
                
                if (snake.GameType == "Closed Border")
                {
                    this.snake.CheckBiteBorder(ref this.isGameOver);
                }

                if (this.snake.CheckEatFood(this.food))
                {
                    this.food.Paint();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(playground.LeftBorder, playground.UpBorder - 2);
                    Console.Write($"Score: {snake.Score}");
                }
                Thread.Sleep(this.snake.Interval);
            }

            EndGame.Exit(snake.Score);
        }

         public static void StartGame(int PlaygroundBorderLeft, int PlaygroundBorderRight,
                              int PlaygroundBorderUp, int PlaygroundBorderDown){
            Console.SetWindowSize(80, 50);
            Colorful.Console.WriteAscii("Snake Game", Color.FromArgb(0,255,255));
            Engine e = new Engine(PlaygroundBorderLeft, PlaygroundBorderRight,
                                    PlaygroundBorderUp, PlaygroundBorderDown);
            e.ShowMenu();
            e.Run();
        }


    }
}