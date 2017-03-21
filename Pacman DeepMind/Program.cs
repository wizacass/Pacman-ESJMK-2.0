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

                rc.AddResult(new ResultItem(game._score, game._turnCounter, pgp.GenesActive));

                pgp.RandomMutation();

            }

            List<ResultItem> list = rc.Sort();
            Logger.logList(list);

            Logger.logEndSession();

            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
        }
    }
}
