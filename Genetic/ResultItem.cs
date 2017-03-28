namespace Genetic
{
    using System.Collections.Generic;

    public class ResultItem
    {
        public int _score;
        public int _turnCount;

        private List<Gene> _listActiveGenes;

        public int Score { get { return _score;  } }
        public int TurnCount { get { return _turnCount; } }
        public List<Gene> ListActiveGenes { get { return _listActiveGenes; } }

        public ResultItem(int score, int turnCount, IEnumerable<Gene> enumerableGenesActive)
        {
            _score = score;
            _turnCount = turnCount;
            _listActiveGenes = new List<Gene>();

            foreach (var gene in enumerableGenesActive)
                _listActiveGenes.Add(gene);
        }
    }
}
