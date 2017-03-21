namespace Genetic
{
    using System;
    using System.Collections.Generic;

    public class Generation
    {
        private List<Gene> _listAllGenes = new List<Gene>();
        private List<Gene> _listActiveGenes = new List<Gene>();

        protected List<Gene> GenesAll
        {
            get
            {
                return _listAllGenes;
            }
        }

        public List<Gene> GenesActive
        {
            get
            {
                return _listActiveGenes;
            }
        }

        protected void InitializeActiveGenes()
        {
            _listActiveGenes.Clear();

            foreach (var gene in _listAllGenes)
            {
                _listActiveGenes.Add(gene);
            }
        }

        public void RandomMutation()
        {
            Random rnd = new Random();

            _listActiveGenes.Clear();

            foreach (var gene in _listAllGenes)
            {
                if (rnd.Next(2) != 0)
                {
                    _listActiveGenes.Add(gene);
                }
            }
        }

        public void CrossBreed(Generation generation)
        {
            // _listActiveGenes.Add(gene)
        }
    }
}
