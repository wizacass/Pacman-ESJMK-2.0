namespace EnvironmentObjects
{
    using System.Collections.Generic;

    public static class Board
    {
        static public bool LeftMove(int x, int y, char[,] board)
        {
            if (y == 0)
                return false;

            if (board[x, y - 1] == '#')
                return false;

            return true;
        }

        static public bool RightMove(int x, int y, int boardSizeY, char[,] board)
        {
            if (y == boardSizeY - 1)
                return false;

            if (board[x, y + 1] == '#')
                return false;

            return true;
        }

        static public bool UpMove(int x, int y, char[,] board)
        {
            if (x == 0)
                return false;

            if (board[x - 1, y] == '#')
                return false;

            return true;
        }

        static public bool DownMove(int x, int y, int boardSizeX, char[,] board)
        {
            if (x == boardSizeX - 1)
                return false;

            if (board[x + 1, y] == '#')
                return false;

            return true;
        }

        static public bool IsFood(int x, int y, char[,] board)
        {
            return (board[x, y] == '+');
        }

        static public bool IsGhost(int x, int y, char[,] board)
        {
            return (board[x, y] == 'G');
        }

        static public bool IsGhostAround(int x, int y, char[,] board)
        {
            for (int xi = x - 1; xi <= x + 1; xi++)
            {
                for (int yi = y - 1; yi <= y + 1; yi++)
                {
                    if (board[xi, yi] == 'G')
                    {
                        return true;
                    }
                }
            }     

            return false;
        }

        static public bool FoodLineUp(int x, int y, char[,] board)
        {
            while (board[--x, y] != '#')
                if (board[x, y] == '+')
                    return true;
            return false;
        }

        static public bool FoodLineDown(int x, int y, char[,] board)
        {
            while (board[++x, y] != '#')
                if (board[x, y] == '+')
                    return true;
            return false;
        }

        static public bool FoodLineLeft(int x, int y, char[,] board)
        {
            while (board[x, --y] != '#')
                if (board[x, y] == '+')
                    return true;
            return false;
        }

        static public bool FoodLineRight(int x, int y, char[,] board)
        {
            while (board[x, ++y] != '#')
                if (board[x, y] == '+')
                    return true;
            return false;
        }

        static public int BestLineUp(int x, int y, char[,] board)
        {
            int c = 0;
            while (board[--x, y] != '#')
                if (board[x, y] == '+')
                    c++;
            return c; 
        }

        static public int BestLineDown(int x, int y, char[,] board)
        {
            int c = 0;
            while (board[++x, y] != '#')
                if (board[x, y] == '+')
                    c++;
            return c;
        }

        static public int BestLineLeft(int x, int y, char[,] board)
        {
            int c = 0;
            while (board[x, --y] != '#')
                if (board[x, y] == '+')
                    c++;
            return c;
        }

        static public int BestLineRight(int x, int y, char[,] board)
        {
            int c = 0;
            while (board[x, ++y] != '#')
                if (board[x, y] == '+')
                    c++;
            return c;
        }

        static public int BestLine(int[] val)
        {
            int m = 0;
            for (int i = 1; i < 4; i++)
                if (val[i] > val[m])
                    m = i;
            return m;
        }
    }
}
