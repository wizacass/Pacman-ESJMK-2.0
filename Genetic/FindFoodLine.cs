namespace Genetic
{
    using System.Collections.Generic;

    using EnvironmentObjects;

    public class FindFoodLine : PacManEnvironmentAwareGene
    {
        public FindFoodLine() : base()
        {
            geneName = "FindFoodLine";
        }

        public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
        {
            char[,] board = environment.Board;
            int x = environment.PacManPositionX;
            int y = environment.PacManPositionY;

            List<Directions> listDirectionsAvailable = new List<Directions>();
            List<Directions> listDirectionsIsFood = new List<Directions>();

            if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Down);

                if (Board.FoodLineDown(x, y, board)) //x+1
                {
                    listDirectionsIsFood.Add(Directions.Down);
                }
            }

            if (Board.UpMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Up);

                if (Board.FoodLineUp(x, y, board)) //x-1
                {
                    listDirectionsIsFood.Add(Directions.Up);
                }
            }

            if (Board.LeftMove(x, y, board))
            {
                listDirectionsAvailable.Add(Directions.Left);

                if (Board.FoodLineLeft(x, y, board)) //y-1
                {
                    listDirectionsIsFood.Add(Directions.Left);
                }
            }

            if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
            {
                listDirectionsAvailable.Add(Directions.Right);

                if (Board.FoodLineRight(x, y, board)) //y+1
                {
                    listDirectionsIsFood.Add(Directions.Right);
                }
            }

            if (listDirectionsIsFood.Count > 0)
                return listDirectionsIsFood;
            else
                return listDirectionsAvailable;

        }

    }
}
