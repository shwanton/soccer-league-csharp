using System;
using System.Collections.Generic;
using System.Linq;
using League;
using Xunit;

namespace Tests
{
    public class PrinterTests
    {
        [Fact]
        public void Printer_Print_ShouldPrintStats()
        {
            var stats = Fixtures.Ranked();
            var printer = new Printer(stats);

            var expected = Fixtures.Output();

            Assert.Equal(expected, printer.Print());
        }
    }
}
