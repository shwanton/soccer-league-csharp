using System;
using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;
using League;
using Xunit;

namespace Tests
{
    public class RankerTests
    {
        [Fact]
        public void Ranker_Rank_ShouldRankStats()
        {
            var stats = Fixtures.Sorted();

            var expected = Fixtures.Ranked();

            expected.ShouldDeepEqual(Ranker.Rank(stats));
        }
    }
}
