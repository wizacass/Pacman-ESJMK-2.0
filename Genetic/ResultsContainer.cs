namespace Genetic
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ResultsContainer
    {
        private List<ResultItem> _listResults = new List<ResultItem>();

        private List<List<Gene>> _listOfListsGenesAttempted = new List<List<Gene>>();

        public bool AreGenesAttempted(List<Gene> listGenes)
        {
            bool areAttempted = false;
            int countListGenes = listGenes.Count;

            if (countListGenes == 0)
                return true;

            foreach (var list in _listOfListsGenesAttempted)
            {
                if (countListGenes != list.Count)
                    continue;

                for (int i = 0; i < list.Count; i++)
                {
                    Gene attemptedGene = list[i];
                    bool isFound = false;

                    foreach (var gene in listGenes)
                    {
                        if (gene.GetType() == attemptedGene.GetType())
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                        break;

                    if (i == list.Count - 1)
                        areAttempted = true;
                }

                if (areAttempted)
                    break;
            }

            return areAttempted;
        }


        public void AddResult(ResultItem item)
        {
            _listResults.Add(item);

            if (!AreGenesAttempted(item.ListActiveGenes))
            {
                List<Gene> attemptedGenes = new List<Gene>();

                foreach (var gene in item.ListActiveGenes)
                    attemptedGenes.Add(gene);

                _listOfListsGenesAttempted.Add(attemptedGenes);
            }
        }

        public List<ResultItem> SortByScore()
        {
            List<ResultItem> listSorted = new List<ResultItem>();

            foreach (var item in _listResults)
            {
                listSorted.Add(item);
            }

            listSorted.Sort(new ResultItemComparer());

            return listSorted;
        }
    }

    public class ResultItemComparer : IComparer<ResultItem>
    {
        int IComparer<ResultItem>.Compare(ResultItem x, ResultItem y)
        {
            if (x.Score > y.Score)
            {
                return -1;
            }
            else if (x.Score < y.Score)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
