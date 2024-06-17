using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Xunit;
using System;

namespace GildedRoseTests.Features.DailyUpdate.Handlers
{
    public class BackstagePassHandlerTests
    {
        [Fact]
        public void Update_QualityIncreasesByOneWhenMoreThanTenDays()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void Update_QualityIncreasesByTwoWhenTenDaysOrLess()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void Update_QualityIncreasesByThreeWhenFiveDaysOrLess()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void Update_QualityDropsToZeroAfterConcert()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotExceedFifty()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Update_SellInDecreasesByOne()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var handler = new BackstagePassHandler();
            handler.Update(item);
            Assert.Equal(14, item.SellIn);
        }

        [Fact]
        public void Update_NullItem_ThrowsArgumentNullException()
        {
            var handler = new BackstagePassHandler();
            Assert.Throws<ArgumentNullException>(() => handler.Update(null));
        }
    }
}
