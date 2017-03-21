namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class GoWhereFoodIs : PacManEnvironmentAwareGene
    {
        public GoWhereFoodIs() : base()
        {
            geneName = "GoWhereFoodIs";
        }

        public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
        {
            char[,] board = environment.Board;
            int x = environment.PacManPositionX;
            int y = environment.PacManPositionY;

            List<Directions> listDirectionsAvailable = new List<Directions>();
            List<Directions> listDirectionsFood = new List<Directions>();

            if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Down);

                if (Board.IsFood(x + 1, y, board))
                {
                    listDirectionsFood.Add(Directions.Down);
                }
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);

                if (Board.IsFood(x - 1, y, board))
                {
                    listDirectionsFood.Add(Directions.Up);
                }
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);

                if (Board.IsFood(x, y - 1, board))
                {
                    listDirectionsFood.Add(Directions.Left);
                }
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);

                if (Board.IsFood(x, y + 1, board))
                {
                    listDirectionsFood.Add(Directions.Right);
                }
            }

            if (listDirectionsFood.Count > 0)
                return listDirectionsFood;
            else
                return listDirectionsAvailable;
        }
    }
}
