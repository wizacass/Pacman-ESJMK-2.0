﻿namespace Genetic
{
    public class PacManEnvironment
    {
        private char[,] _board;
        //private int _pacManPositionY;

        public char[,] Board { get { return _board; } }
        public int PacManPositionX { get; private set; }
        public int PacManPositionY { get; private set; }
        public int? PacManPreviousPositionX { get; private set; }
        public int? PacManPreviousPositionY { get; private set; }

        public PacManEnvironment(
            char[,] board,
            int pacManPositionX,
            int pacManPositionY,
            int? pacManPreviousPositionX,
            int? pacManPreviousPositionY)
        {
            _board = board;
            PacManPositionX = pacManPositionX;
            PacManPositionY = pacManPositionY;
            PacManPreviousPositionX = pacManPreviousPositionX;
            PacManPreviousPositionY = pacManPreviousPositionY;
        }
    }
}
