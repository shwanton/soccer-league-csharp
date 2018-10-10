using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using League;
using Xunit;

namespace Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Integration_ShouldPrintLeagueStats()
        {
            var fileName = "test.txt";
            var input = Fixtures.Input();

            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {
                    fileName, new MockFileData(input)
                }
            });

            var loader = new GameParser(new FileLoader(fileSystem, fileName));
            var league = new LeagueStats(loader);

            var expected = Fixtures.Output();
            var result = league.GetSeason();

            Assert.Equal(expected, result);
        }
    }
}
