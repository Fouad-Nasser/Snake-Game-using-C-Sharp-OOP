using System;
using System.Threading;
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


    }
}