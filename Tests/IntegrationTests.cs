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
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {
                    fileName, new MockFileData(Fixtures.Input())
                }
            });

            var loader = new GameParser(new FileLoader(fileSystem, fileName));
            var league = new LeagueStats(loader);

            var expected = Fixtures.Output();

            Assert.Equal(expected, league.GetSeason());
        }
    }
}
