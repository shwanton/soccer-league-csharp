using System;
using Xunit;
using League;
using System.Collections.Generic;

namespace Tests
{
    public class GameParserTests
    {

        [Fact]
        public void GameParser_Parse_ShouldReturnParsedGames()
        {
            var data = "Lions 3, Snakes 3\nTarantulas 1, FC Awesome 0\n";
            var parser = new GameParser(data);

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
                    "FC Awesome", "0"

                },
            };

            var expected = new Dictionary<string, string>[] { game1, game2 };

            Assert.Equal(expected, parser.Parse());
        }
    }
}
