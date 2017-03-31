namespace Genetic
{
	using System.Collections.Generic;

	using EnvironmentObjects;

	class DoNotGoWhereGhostIs : PacManEnvironmentAwareGene
	{
		public DoNotGoWhereGhostIs() : base()
        {
			geneName = "DoNotGoWhereGhostIs";
		}

		public override List<Directions> GetPossibleDirections(PacManEnvironment environment)
		{
			char[,] board = environment.Board;
			int Px = environment.PacManPositionX;
			int Py = environment.PacManPositionY;
			int Gx = environment.GhostPositionX;
			int Gy = environment.GhostPositionY;

			int dx = Gx - Px;   //delta X
			int dy = Gy - Py;   //delta Y
			double tg = 0.0;

			List<Directions> listDirectionsAvailable = new List<Directions>();
			List<Directions> listDirectionsNoGhost = new List<Directions>();

			if (Board.DownMove(Px, Py, board.GetUpperBound(0) + 1, board))
				listDirectionsAvailable.Add(Directions.Down);

			if (Board.UpMove(Px, Py, board))
				listDirectionsAvailable.Add(Directions.Up);

			if (Board.LeftMove(Px, Py, board))
				listDirectionsAvailable.Add(Directions.Left);

			if (Board.RightMove(Px, Py, board.GetUpperBound(1) + 1, board))
				listDirectionsAvailable.Add(Directions.Right);

			if (Board.DistanceAtoB(Px, Py, Gx, Gy) < 10)
			{
				if (dx == 0 || dy == 0)
				{
					if (dy > 0)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}

					if (dy < 0)
					{
						listDirectionsNoGhost.Add(Directions.Up);
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
					}

					if (dx > 0)
					{
						listDirectionsNoGhost.Add(Directions.Right);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}

					if (dx < 0)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Right);
					}
				}
				else
					tg = dy / (dx * 1.0f);
				
				if (dx > 0 && dy > 0)
				{
					if (tg == 1)
					{
						listDirectionsNoGhost.Add(Directions.Up);
						listDirectionsNoGhost.Add(Directions.Left);
					}

					if (tg < 1)
					{
						listDirectionsNoGhost.Add(Directions.Right);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}

					if (tg > 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}
				}
				
				if (dx < 0 && dy > 0)
				{
					if (tg == 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Left);
					}

					if (tg < 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
						listDirectionsNoGhost.Add(Directions.Left);
					}

					if (tg > 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}
				}
				
				if (dx < 0 && dy < 0)
				{
					if (tg == 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
					}

					if (tg < 1)
					{
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
						listDirectionsNoGhost.Add(Directions.Left);
					}

					if (tg > 1)
					{
						listDirectionsNoGhost.Add(Directions.Up);
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
					}
				}

				if (dx > 0 && dy < 0)
				{
					if (tg == 1)
					{
						listDirectionsNoGhost.Add(Directions.Up);
						listDirectionsNoGhost.Add(Directions.Right);
					}

					if (tg < 1)
					{
						listDirectionsNoGhost.Add(Directions.Right);
						listDirectionsNoGhost.Add(Directions.Left);
						listDirectionsNoGhost.Add(Directions.Up);
					}

					if (tg > 1)
					{
						listDirectionsNoGhost.Add(Directions.Up);
						listDirectionsNoGhost.Add(Directions.Down);
						listDirectionsNoGhost.Add(Directions.Right);
					}
				}
			}

			if (listDirectionsNoGhost.Count > 0)
				return listDirectionsNoGhost;
			else
				return listDirectionsAvailable;
		}
	}
}
