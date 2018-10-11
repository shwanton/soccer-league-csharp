using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using League;
using DeepEqual.Syntax;

namespace Tests
{
    public class SorterTests
    {
        [Fact]
        public void Sorter_Sort_ShouldSortStatsByScoreAndName()
        {
            var stats = Fixtures.Stats();

            var expected = Fixtures.Sorted();

            expected.ShouldDeepEqual(Sorter.Sort(stats));
        }
    }
}
