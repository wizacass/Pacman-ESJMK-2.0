namespace Genetic
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ResultsContainer
    {
        private List<ResultItem> _listResults = new List<ResultItem>();

        public void AddResult(ResultItem item)
        {
            _listResults.Add(item);
        }

        public List<ResultItem> Sort()
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
