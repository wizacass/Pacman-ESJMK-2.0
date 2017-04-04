namespace Pacman_DeepMind
{
	using Genetic;
	using Extensions;
	using System.Collections.Generic;

	class Program
	{
		static void Main(string[] args)
		{
			Logger.logNewSession();

			PacManGameParameters pgp = new PacManGameParameters();
			ResultsContainer rc = new ResultsContainer();

			/*do
			{
				Game game = new Game(pgp);

				pgp.RandomMutation();

			} while (true);*/

			for (int i = 0; i < 10; i++)
			{
				Game game = new Game(pgp);

				game.GameStart();
				game.GameLoop(pgp);
				game.GameEnd();

			//TODO: Set Flag for Gene isCrossbred : bool
				rc.AddResult(new ResultItem(game._score, game._turnCounter, pgp.GenesActive));

				do
				{
					pgp.RandomMutation();
				} while (rc.AreGenesAttempted(pgp.GenesActive));
			}
			
			for (int i = 0; i < 100; i++)
			{
				Game game = new Game(pgp);

				game.GameStart();
				game.GameLoop(pgp);
				game.GameEnd();

				rc.AddResult(new ResultItem(game._score, game._turnCounter, pgp.GenesActive));

				do
				{
					bool isValidCrossBreed  = false;
					bool isCrosbreedFound = pgp.CrossBreed(rc);

					if (isCrosbreedFound)
					{
						if (!rc.AreGenesAttempted(pgp.GenesActive))
						{
							isValidCrossBreed = true;
						}
					}

					if (!isValidCrossBreed)
						pgp.RandomMutation();

				} while (rc.AreGenesAttempted(pgp.GenesActive));
			}

			List<ResultItem> list = rc.SortByScore();
			Logger.logList(list);

			Logger.logEndSession();

			//Console.WriteLine("Press any key to exit");
			//Console.ReadKey();
		}


	}
}
