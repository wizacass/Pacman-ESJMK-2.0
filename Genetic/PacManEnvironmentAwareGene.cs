namespace Genetic
{
    using System.Collections.Generic;

    public enum Directions
    {

        Left,
        Up,
        Right,
        Down

    }

    public abstract class PacManEnvironmentAwareGene : Gene
    {
        public PacManEnvironmentAwareGene()
        {
           
        }

        public abstract List<Directions> GetPossibleDirections(PacManEnvironment environment);
    }
}
