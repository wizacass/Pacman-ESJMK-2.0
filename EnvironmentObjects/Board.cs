namespace EnvironmentObjects
{
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
    }
}
