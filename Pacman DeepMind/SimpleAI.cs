namespace Pacman_DeepMind
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Genetic;

    public class SimpleAI : IEnumerator<Tuple<int, int>>
    {
        private Level _level;

        int pManX;
        int pManY;

        public SimpleAI(Level level)
        {
            _level = level;

            pManX = _level.pX;
            pManY = _level.pY;
        }

        public void Run()
        {

           // Move(pManX, pManY);
        }

        Directions FindMove(int x, int y, char[,] board)
        {
            //const int MoveLimit = 10;

            Directions current = Directions.Right;
            //Directions? comeFrom = null;
            bool moveFound = false;
            bool canMove;

            int moveCount = 0;

            Random rnd = new Random();
            int rndDir;

            do
            {

                switch (current)
                {
                    case Directions.Left:

                        canMove = LeftMove(x, y, board);

                        if (!canMove)
                        {
                            rndDir = rnd.Next(0, 4);
                            current = (Directions)rndDir;     
                            //current = Directions.Up;
                        }
                        else
                        {
                            moveFound = true;
                        }
                        break;

                    case Directions.Up:

                        canMove = UpMove(x, y, board);

                        if (!canMove)
                        {
                            rndDir = rnd.Next(0, 4);
                            current = (Directions)rndDir;
                            //current = Directions.Right;
                        }
                        else
                        {
                            moveFound = true;
                        }
                        break;

                    case Directions.Right:

                        canMove = RightMove(x, y, _level.y, board);

                        if (!canMove)
                        {
                            rndDir = rnd.Next(0, 4);
                            current = (Directions)rndDir;
                            //current = Directions.Down;
                        }
                        else
                        {
                            moveFound = true;
                        }
                        break;

                    case Directions.Down:

                        canMove = DownMove(x, y, _level.x, board);

                        if (!canMove)
                        {
                            rndDir = rnd.Next(0, 4);
                            current = (Directions)rndDir;
                            //current = Directions.Left;
                        }
                        else
                        {
                            moveFound = true;
                        }
                        break;
                }

                moveCount++;
            }
            while (!moveFound);

            /*if (LeftMove(x, y, board))
            {

            }
            else if (UpMove(x, y, board))
            {

            }
            else if (RightMove(x, y, _level.x, board))
            {

            }
            else if (DownMove(x, y, _level.y, board))
            {

            }*/

            return current;
        }

        bool LeftMove(int x, int y, char[,] board)
        {
            if (y == 0)
                return false;

            if (board[x, y - 1] == '#')
                return false;

            return true;
        }

        bool RightMove(int x, int y, int boardSizeY, char[,] board)
        {
            if (y == boardSizeY - 1)
                return false;

            if (board[x, y + 1] == '#')
                return false;

            return true;
        }

        bool UpMove(int x, int y, char[,] board)
        {
            if (x == 0)
                return false;

            if (board[x - 1, y] == '#')
                return false;

            return true;
        }

        bool DownMove(int x, int y, int boardSizeX, char[,] board)
        {
            if (x == boardSizeX - 1)
                return false;

            if (board[x + 1, y] == '#')
                return false;

            return true;
        }

        public bool MoveNext()
        {
            Tuple<int, int> delta = DirToDelta(FindMove(pManX, pManY, _level._board));

            pManX += delta.Item1;
            pManY += delta.Item2;

            return delta != null;
        }

        public Tuple<int, int> Current
        {
            get
            {
                return new Tuple<int, int>(pManX, pManY);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        Tuple<int, int> DirToDelta(Directions direction)
        {
            Tuple<int, int> ret = null;

            switch (direction)
            {
                case Directions.Left:
                    ret = new Tuple<int, int>(0, -1);
                    break;

                case Directions.Right:
                    ret = new Tuple<int, int>(0, 1);
                    break;

                case Directions.Up:
                    ret = new Tuple<int, int>(-1, 0);
                    break;

                case Directions.Down:
                    ret = new Tuple<int, int>(1, 0);
                    break;
            }

            return ret;
        }

        public void Dispose()
        {
            
        }

        public void Reset()
        {
            
        }
    }
}
