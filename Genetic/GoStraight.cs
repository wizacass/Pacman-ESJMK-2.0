namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class GoStraight : PacManEnvironmentAwareGene
    {
        public GoStraight() : base()
        {
            geneName = "GoStraight";
        }

        public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
        {
            char[,] board = environment.Board;
            int x = environment.PacManPositionX;
            int y = environment.PacManPositionY;

            int? xPrv = environment.PacManPreviousPositionX;
            int? yPrv = environment.PacManPreviousPositionY;

            List<Directions> listDirectionsAvailable = new List<Directions>();
            List<Directions> listDirectionsNotPrevious = new List<Directions>();

            if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Down);

                if (xPrv == null || yPrv == null)
                    listDirectionsNotPrevious.Add(Directions.Down);
                else if (x - 1 == xPrv && y == yPrv)
                    listDirectionsNotPrevious.Add(Directions.Down);
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);

                if (xPrv == null || yPrv == null)
                    listDirectionsNotPrevious.Add(Directions.Up);
                else if (x + 1 == xPrv && y == yPrv)
                    listDirectionsNotPrevious.Add(Directions.Up);
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);

                if (xPrv == null || yPrv == null)
                    listDirectionsNotPrevious.Add(Directions.Left);
                else if (x == xPrv && y + 1 == yPrv)
                    listDirectionsNotPrevious.Add(Directions.Left);
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);

                if (xPrv == null || yPrv == null)
                    listDirectionsNotPrevious.Add(Directions.Right);
                else if (x == xPrv && y - 1 == yPrv)
                    listDirectionsNotPrevious.Add(Directions.Right);
            }

            if (listDirectionsNotPrevious.Count > 0)
                return listDirectionsNotPrevious;
            else
                return listDirectionsAvailable;
        }
    }
}
