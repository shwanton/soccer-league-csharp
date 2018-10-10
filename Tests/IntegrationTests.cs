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
            var loader = new FileLoader(fileSystem, fileName);
            var data = loader.LoadData();

            var parsed = new GameParser(data).Parse();
            var stats = new StatsCalulator(parsed).Calculate();
            var sorted = new Sorter(stats).Sort();
            var ranked = new Ranker(sorted).Rank();
            var result = new Printer(ranked).Print();

            var expected = Fixtures.Output();

            Assert.Equal(expected, result);
        }
    }
}
