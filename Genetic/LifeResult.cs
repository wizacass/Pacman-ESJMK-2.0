namespace Genetic
{
    public abstract class LifeResult
    {
        public bool IsBetterThan(LifeResult lifeResult)
        {
            return IntValue > lifeResult.IntValue;
        }

        protected abstract int IntValue { get;  }
    }
}
