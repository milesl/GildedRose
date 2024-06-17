using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Xunit;
using System;

namespace GildedRoseTests.Features.DailyUpdate.Handlers
{
    public class NormalItemHandlerTests
    {
        [Fact]
        public void Update_QualityDecreasesByOne()
        {
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 20 };
            var handler = new NormalItemHandler();
            handler.Update(item);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void Update_SellInDecreasesByOne()
        {
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 20 };
            var handler = new NormalItemHandler();
            handler.Update(item);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void Update_QualityDecreasesByTwoAfterSellInDate()
        {
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 20 };
            var handler = new NormalItemHandler();
            handler.Update(item);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotGoBelowZero()
        {
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 0 };
            var handler = new NormalItemHandler();
            handler.Update(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotGoBelowZeroAfterSellInDate()
        {
            var item = new Item { Name = "Normal Item", SellIn = -1, Quality = 1 };
            var handler = new NormalItemHandler();
            handler.Update(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Update_NullItem_ThrowsArgumentNullException()
        {
            var handler = new NormalItemHandler();
            Assert.Throws<ArgumentNullException>(() => handler.Update(null));
        }
    }
}
