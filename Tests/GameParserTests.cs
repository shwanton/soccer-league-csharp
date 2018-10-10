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
            var loader = new MockDataLoader();
            var parser = new GameParser(loader);

            var expected = Fixtures.Games();

            expected.ShouldDeepEqual(parser.LoadGames());
        }
    }

    public class MockDataLoader : IDataLoader
    {
        public string LoadData()
        {
            return Fixtures.Input();
        }
    }
}
