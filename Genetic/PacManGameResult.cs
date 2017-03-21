namespace Genetic
{
    public class PacManGameResult : LifeResult
    {
        private int _score;

        protected override int IntValue
        {
            get
            {
                return _score;
            }
        }

        public int Score
        {
            set
            {
                _score = value;
            }
        }
    }
}
