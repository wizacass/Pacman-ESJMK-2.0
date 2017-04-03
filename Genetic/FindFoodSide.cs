namespace Genetic
{
	using System.Collections.Generic;

	using EnvironmentObjects;
	/// <summary>
	/// Finds the sides where food is
	/// </summary>
	class FindFoodSide : PacManEnvironmentAwareGene
	{
		public FindFoodSide() : base()
        {
			geneName = "FindFoodSide";
		}

		public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
		{
			char[,] board = environment.Board;
			int x = environment.PacManPositionX;
			int y = environment.PacManPositionY;

			List<Directions> listDirectionsAvailable = new List<Directions>();
			List<Directions> listDirectionsIsFood = new List<Directions>();

			if (Board.DownMove(x, y, board.GetUpperBound(0) + 1, board))
				listDirectionsAvailable.Add(Directions.Down);

			if (Board.UpMove(x, y, board))
				listDirectionsAvailable.Add(Directions.Up);

			if (Board.LeftMove(x, y, board))
				listDirectionsAvailable.Add(Directions.Left);

			if (Board.RightMove(x, y, board.GetUpperBound(1) + 1, board))
				listDirectionsAvailable.Add(Directions.Right);


			if (Board.FoodSideDown(x, board))
				listDirectionsIsFood.Add(Directions.Down);

			if (Board.FoodSideLeft(y, board))
				listDirectionsIsFood.Add(Directions.Left);

			if (Board.FoodSideRight(y, board))
				listDirectionsIsFood.Add(Directions.Right);

			if (Board.FoodSideUp(x, board))
				listDirectionsIsFood.Add(Directions.Up);

			if (listDirectionsIsFood.Count > 0)
				return listDirectionsIsFood;
			else
				return listDirectionsAvailable;

		}
	}
}
