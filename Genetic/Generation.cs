namespace Genetic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public bool CrossBreed(ResultsContainer resultsContainer)
        {
            List<Gene> listGenesChild;
            if (CrosbreedBestTwo(resultsContainer, out listGenesChild))
            {

                _listActiveGenes.Clear();

                foreach (var gene in listGenesChild)
                    _listActiveGenes.Add(gene);

                return true;
            }
            else
                return false;
        }

        static bool CrosbreedBestTwo(ResultsContainer resultsContainer, out List<Gene> listGenesChild)
        {
            listGenesChild = null;

            ResultItem[] arrayCandidates;

            bool areCandidatesFound = FindCrosbreedCandidates(resultsContainer, out arrayCandidates);

            if (areCandidatesFound)
                return ProduceChild(arrayCandidates[0].ListActiveGenes, arrayCandidates[1].ListActiveGenes, out listGenesChild);
            else
                return false;
        }

        static bool FindCrosbreedCandidates(ResultsContainer resultsContainer, out ResultItem[] arrayCandidates)
        {
            arrayCandidates = null;

            List<ResultItem> listBestToWorst = resultsContainer.SortByScore();

            if (listBestToWorst.Count < 2)
                return false;

            arrayCandidates = new ResultItem[2];

            arrayCandidates[0] = listBestToWorst[0];
            arrayCandidates[1] = listBestToWorst[1];

            return true;
        }

        static bool ProduceChild(List<Gene> listGenesParent1, List<Gene> listGenesParent2, out List<Gene> listGenesChild)
        {
            List<Gene> listChildGenes = new List<Gene>();
            bool isUseful = false;

            foreach (var geneParent1 in listGenesParent1)
            {
                listChildGenes.Add(geneParent1);
            }

            foreach (var geneParent2 in listGenesParent2)
            {
                bool isFound = false;

                foreach (var geneParent1 in listGenesParent1)
                {
                    if (geneParent2.GetType() == geneParent1.GetType())
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    isUseful = true;
                    listChildGenes.Add(geneParent2);
                }
            }

            listGenesChild = listChildGenes;
            return isUseful;
        }
    }
}
