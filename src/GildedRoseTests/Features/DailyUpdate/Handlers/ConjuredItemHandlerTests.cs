using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Xunit;
using System;

namespace GildedRoseTests.Features.DailyUpdate.Handlers
{
    public class ConjuredItemHandlerTests
    {
        [Fact]
        public void Update_QualityDecreasesByTwo()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 };
            var handler = new ConjuredItemHandler();
            handler.Update(item);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void Update_SellInDecreasesByOne()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 };
            var handler = new ConjuredItemHandler();
            handler.Update(item);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void Update_QualityDecreasesByFourAfterSellInDate()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 20 };
            var handler = new ConjuredItemHandler();
            handler.Update(item);
            Assert.Equal(16, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotGoBelowZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 1 };
            var handler = new ConjuredItemHandler();
            handler.Update(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Update_QualityDoesNotGoBelowZeroAfterSellInDate()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 3 };
            var handler = new ConjuredItemHandler();
            handler.Update(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Update_NullItem_ThrowsArgumentNullException()
        {
            var handler = new ConjuredItemHandler();
            Assert.Throws<ArgumentNullException>(() => handler.Update(null));
        }
    }
}
