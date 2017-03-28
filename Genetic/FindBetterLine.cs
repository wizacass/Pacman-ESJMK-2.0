namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class FindBetterLine : PacManEnvironmentAwareGene
    {
        public FindBetterLine() : base()
        {
            geneName = "FindBetterLine";
        }

        public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
        {
            char[,] board = environment.Board;
            int x = environment.PacManPositionX;
            int y = environment.PacManPositionY;

            int[] values = new int[4];
            List<Directions> listDirectionsAvailable = new List<Directions>();
            List<Directions> listDirectionsIsBetter = new List<Directions>();

            if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Down);
                values[0] = Board.BestLineDown(x, y, board);
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);
                values[1] = (Board.BestLineUp(x, y, board));
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);
                values[2] = Board.BestLineLeft(x, y, board);
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);
                values[3] = Board.BestLineRight(x, y, board);
            }

            if (Board.BestLine(values) == 0)
                listDirectionsIsBetter.Add(Directions.Down);
            if (Board.BestLine(values) == 1)
                listDirectionsIsBetter.Add(Directions.Up);
            if (Board.BestLine(values) == 2)
                listDirectionsIsBetter.Add(Directions.Left);
            if (Board.BestLine(values) == 3)
                listDirectionsIsBetter.Add(Directions.Right);

            if (listDirectionsIsBetter.Count > 0)
                return listDirectionsIsBetter;
            else
                return listDirectionsAvailable;

        }

    }
}
