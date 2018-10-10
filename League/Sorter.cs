using System;
using System.Collections.Generic;
using System.Linq;

namespace League
{
    public class Sorter
    {
        private List<KeyValuePair<string, int>> _stats;

        public Sorter(List<KeyValuePair<string, int>> stats)
        {
            _stats = stats;
        }

        public List<KeyValuePair<string, int>> Sort()
        {
            return _stats
                .OrderByDescending(team => team.Value)
                .ThenBy(team => team.Key, StringComparer.Ordinal)
                .ToList();
        }
    }
}
