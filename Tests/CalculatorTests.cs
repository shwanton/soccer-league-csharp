using System;
using System.Collections.Generic;
using DeepEqual.Syntax;
using League;
using Xunit;

namespace Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Calculate_ShouldCalculateStats()
        {
            var games = Fixtures.Games();
            var expected = Fixtures.Stats();

            Console.Write(Printer.PrintStats(expected));
            Console.Write(Printer.PrintStats(Calculator.GameStats(games)));

            expected.ShouldDeepEqual(Calculator.GameStats(games));
        }
    }

}
