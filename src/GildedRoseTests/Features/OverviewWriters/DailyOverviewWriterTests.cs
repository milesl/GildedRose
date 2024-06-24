using GildedRoseKata;
using GildedRoseKata.Features.OverviewWriters;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GildedRoseTests.Features.OverviewWriters
{
    [Collection("WriterSequential")]
    public class DailyOverviewWriterTests : IDisposable
    {
        private readonly StringWriter consoleOutput;

        public DailyOverviewWriterTests()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        public void Dispose()
        {
            consoleOutput.Dispose();
            Console.SetOut(Console.Out);
        }

        [Fact]
        public void WriteOverview_ValidInput_WritesCorrectOverview()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 }
            };
            var overviewWriter = new DailyOverviewWriter(items);
            overviewWriter.WriteOverview(1);
            var expectedOutput = "-------- day 1 --------\r\nname, sellIn, quality\r\nAged Brie, 10, 20\r\nSulfuras, Hand of Ragnaros, 5, 80\r\n\r\n";
            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }

        [Fact]
        public void WriteOverview_EmptyItems_WritesHeaderOnly()
        {
            var items = new List<Item>();
            var overviewWriter = new DailyOverviewWriter(items);
            overviewWriter.WriteOverview(1);
            var expectedOutput = "-------- day 1 --------\r\nname, sellIn, quality\r\n\r\n";
            Assert.Equal(expectedOutput, consoleOutput.ToString());
        }

        [Fact]
        public void WriteOverview_NullItems_ThrowsArgumentNullException()
        {
            ICollection<Item> items = null;
            Assert.Throws<ArgumentNullException>(() => new DailyOverviewWriter(items));
        }
    }
}