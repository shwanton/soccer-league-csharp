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
            var game1 = new Dictionary<string, string>
            {
                {
                    "Lions", "3"
                },
                {
                    "Snakes", "3"

                },
            };

            var game2 = new Dictionary<string, string>
            {
                {
                    "Tarantulas", "1"
                },
                {
                    "Snakes", "2"

                },
            };

            var games = new List<Dictionary<string, string>> { game1, game2 };

            var stats = new StatsCalulator(games);

            var expected = new List<KeyValuePair<string, int>>
            {
                KeyValuePair.Create<string, int>("Lions", 1),
                KeyValuePair.Create<string, int>("Snakes", 4),
                KeyValuePair.Create<string, int>("Tarantulas", 0),
            };

            Assert.Equal(expected, stats.Calculate());
        }
    }

}
