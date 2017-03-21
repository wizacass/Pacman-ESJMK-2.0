namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class RunAwayFromGhost2 : PacManEnvironmentAwareGene
    {
        public RunAwayFromGhost2() : base()
        {
            geneName = "RunAwayFromGhost2";
        }

        public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
        {
            char[,] board = environment.Board;
            int x = environment.PacManPositionX;
            int y = environment.PacManPositionY;

            List<Directions> listDirectionsAvailable = new List<Directions>();
            List<Directions> listDirectionsNotGhost = new List<Directions>();

            if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Down);

                if (!Board.IsGhostAround(x + 1, y, board))
                {
                    listDirectionsNotGhost.Add(Directions.Down);
                }
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);

                if (!Board.IsGhostAround(x - 1, y, board))
                {
                    listDirectionsNotGhost.Add(Directions.Up);
                }
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);

                if (!Board.IsGhostAround(x, y - 1, board))
                {
                    listDirectionsNotGhost.Add(Directions.Left);
                }
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);

                if (!Board.IsGhostAround(x, y + 1, board))
                {
                    listDirectionsNotGhost.Add(Directions.Right);
                }
            }

            if (listDirectionsNotGhost.Count > 0)
                return listDirectionsNotGhost;
            else
                return listDirectionsAvailable;
        }
    }
}

