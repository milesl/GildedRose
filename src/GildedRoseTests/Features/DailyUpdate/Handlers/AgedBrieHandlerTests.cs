using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Xunit;
using System;

namespace GildedRoseTests.Features.DailyUpdate.Handlers
{
    public class AgedBrieHandlerTests
    {
        [Fact]
        public void Update_QualityIncreasesByOne()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
            var handler = new AgedBrieHandler();
            handler.Update(item);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void Update_SellInDecreasesByOne()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
            var handler = new AgedBrieHandler();
            handler.Update(item);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void Update_QualityIncreasesByTwoAfterSellInDate()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
            var handler = new AgedBrieHandler();
            handler.Update(item);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotExceedFifty()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
            var handler = new AgedBrieHandler();
            handler.Update(item);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotExceedFiftyAfterSellInDate()
        {
            var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 };
            var handler = new AgedBrieHandler();
            handler.Update(item);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Update_NullItem_ThrowsArgumentNullException()
        {
            var handler = new AgedBrieHandler();
            Assert.Throws<ArgumentNullException>(() => handler.Update(null));
        }
    }
}
