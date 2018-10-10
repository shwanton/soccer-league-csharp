using System;
using System.Collections.Generic;
using League;
using Xunit;

namespace Tests
{
    public class StatsCalculatorTests
    {
        [Fact]
        public void StatsCalculator_Calculate_ShouldCalculateScores()
        {
            var games = Fixtures.Games();

            var stats = new StatsCalulator(games);

            var expected = Fixtures.Stats();

            Assert.Equal(expected, stats.Calculate());
        }
    }

}
