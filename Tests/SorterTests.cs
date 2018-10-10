using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using League;

namespace Tests
{
    public class SorterTests
    {
        [Fact]
        public void Sorter_Sort_ShouldSortStatsByScoreAndName()
        {
            var stats = Fixtures.Stats();
            var sorter = new Sorter(stats);
            var expected = Fixtures.Sorted();

            Assert.Equal(expected, sorter.Sort());
        }
    }
}
