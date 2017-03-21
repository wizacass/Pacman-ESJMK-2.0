namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class RunAwayFromGhost1 : PacManEnvironmentAwareGene
    {
        public RunAwayFromGhost1() : base()
        {
            geneName = "RunAwayFromGhost1";
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

                if (!Board.IsGhost(x + 1, y, board))
                {
                    listDirectionsNotGhost.Add(Directions.Down);
                }
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);

                if (!Board.IsGhost(x - 1, y, board))
                {
                    listDirectionsNotGhost.Add(Directions.Up);
                }
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);

                if (!Board.IsGhost(x, y - 1, board))
                {
                    listDirectionsNotGhost.Add(Directions.Left);
                }
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);

                if (!Board.IsGhost(x, y + 1, board))
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
