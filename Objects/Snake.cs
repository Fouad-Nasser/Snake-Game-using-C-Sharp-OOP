using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Enum;

namespace Snake.Objects
{
    public class Snake
    {
        private int interval;
        private const int MinInterval = 100;
        private const int MaxInterval = 300;
        private const int IntervalDifference = 25;
        private Direction direction;
        private const Direction DefaultDirection = Direction.Right;
        private readonly int leftBorder;
        private readonly int rightBorder;
        private readonly int upBorder;
        private readonly int downBorder;
        private readonly List<SnakePart> body;
        private int score = 0;

       
        public string GameType{get;set;}


        public int Interval
        {
            get
            {
                return this.interval;
            }
            private set
            {
                if ((value >= MinInterval) && (value <= MaxInterval))
                {
                    this.interval = value;
                }
            }
        }
        public Direction Direction{
            get{
                return direction;
            } 
            set{
                direction = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
        }

        public Snake(int leftBorder, int rightBorder, int upBorder, int downBorder)
        {
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.upBorder = upBorder;
            this.downBorder = downBorder;
            this.body = new List<SnakePart>
            {
                new SnakePart(Utilites.GenerateNumber(this.leftBorder + 1, this.rightBorder - 1),
                    Utilites.GenerateNumber(this.upBorder + 1, this.downBorder - 1),
                    ConsoleColor.Green,ConsoleColor.Black,(char)2)
            };
            this.Interval = MaxInterval;
            this.Direction = DefaultDirection;
        }


        public void Move()
        {
            this.EraseLastPosition();
            this.BodyInheritance();
            switch (this.Direction)
            {
                case Direction.Up:
                    this.body[0].Y--;
                    break;
                case Direction.Down:
                    this.body[0].Y++;
                    break;
                case Direction.Left:
                    this.body[0].X--;
                    break;
                case Direction.Right:
                    this.body[0].X++;
                    break;
            }

            
            if (GameType == "Opend Border")
            {
                this.CheckBorder();
                
            }
            

            for (var i = this.body.Count - 1; i >= 0; i--)
            {
                this.body[i]
                   .Paint();
            }
        }
        private void EraseLastPosition()
        {
            var lastSnakePart = this.body.Last();
            Console.SetCursorPosition(lastSnakePart.X, lastSnakePart.Y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

        private void BodyInheritance()
        {
            for (var i = this.body.Count - 1; i > 0; i--)
            {
                this.body[i]
                   .X = this.body[i - 1]
                   .X;
                this.body[i]
                   .Y = this.body[i - 1]
                   .Y;
            }
        }

        private void CheckBorder()
        {
            var head = this.body.First();
            if (head.X == this.leftBorder)
            {
                head.X = this.rightBorder - 1;
            }
            else if (head.X == this.rightBorder)
            {
                head.X = this.leftBorder + 1;
            }
            else if (head.Y == this.upBorder)
            {
                head.Y = this.downBorder - 1;
            }
            else if (head.Y == this.downBorder)
            {
                head.Y = this.upBorder + 1;
            }
        }

        
        public bool CheckEatFood(FoodPart food)
        {
            foreach (var snakePart in this.body)
            {
                if ((snakePart.X == food.X) && (snakePart.Y == food.Y))
                {
                    this.AddSnakePart();
                    this.score++;
                    this.Interval -= IntervalDifference;
                    return true;
                }
            }

            return false;
        }
        private void AddSnakePart()
        {
            var last = this.body.Last();
            this.body.Add(new SnakePart(last.X, last.Y));
        }

        public void CheckBiteItself(ref bool isGameOver)
        {
            var head = this.body.First();
            foreach (var snakePart in this.body.Skip(1))
            {
                if ((snakePart.X == head.X) && (snakePart.Y == head.Y))
                {
                    isGameOver = true;
                    return;
                }
            }
        }

        public void CheckBiteBorder(ref bool isGameOver)
        {
            var head = this.body.First();
                        if(head.X==this.leftBorder || head.X==this.rightBorder
                           || head.Y == this.upBorder || head.Y == this.downBorder)
                        {
                            isGameOver = true;
                        }
        }
    }
}