namespace Genetic
{
    using System;
    using System.Collections.Generic;

    public class PacManGameParameters : Generation
    {
        public PacManGameParameters()
        {
            GenesAll.Add(new GoWhereFoodIs());
            GenesAll.Add(new RunAwayFromGhost1());
            GenesAll.Add(new RunAwayFromGhost2());
            GenesAll.Add(new GoSameDirection());
            GenesAll.Add(new GoStraight());
            GenesAll.Add(new FindFoodLine());
			//GenesAll.Add(new FindBetterLine());
			GenesAll.Add(new DoNotGoWhereGhostIs());

            InitializeActiveGenes();
        }

        public Directions? GetMoveDirection(PacManEnvironment environment)
        {
            Random rnd = new Random();
            Directions? directions = null;
            List<Directions> listCurrent = null;

            foreach (var gene in GenesActive)
            {
                var possibleDirections = ((PacManEnvironmentAwareGene)gene).GetPossibleDirections(environment);

                if (listCurrent == null)
                    listCurrent = possibleDirections;
                else
                {
                    List<Directions> listTemp = new List<Directions>();

                    foreach (var direct in possibleDirections)
                    {
                        if (listCurrent.Contains(direct))
                        {
                            listTemp.Add(direct);
                        }
                    }

                    listCurrent = listTemp;
                }
            }

            if (listCurrent == null || listCurrent.Count == 0)
                directions = null;
            else
                directions = listCurrent[rnd.Next(listCurrent.Count)];

            return directions;
        }
    }
}
