using System;
using Xunit;
using League;
using System.Collections.Generic;
using System.Linq;
using DeepEqual.Syntax;

namespace Tests
{
    public class GameParserTests
    {

        [Fact]
        public void GameParser_Parse_ShouldReturnParsedGames()
        {
            var data = Fixtures.Input();
            var parser = new GameParser(data);

            var expected = Fixtures.Games();
            var result = parser.Parse();

            expected.ShouldDeepEqual(result);
        }
    }
}
