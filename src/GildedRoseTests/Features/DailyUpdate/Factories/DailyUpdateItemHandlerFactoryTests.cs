using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Factories;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using System;
using Xunit;

namespace GildedRoseTests.Features.DailyUpdate.Factories
{
    public class DailyUpdateItemHandlerFactoryTests
    {
        [Theory]
        [InlineData("Aged Brie", typeof(AgedBrieHandler))]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemHandler))]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassHandler))]
        [InlineData("Conjured Mana Cake", typeof(ConjuredItemHandler))]
        [InlineData("Normal Item", typeof(NormalItemHandler))]
        public void GetHandler_ReturnsCorrectHandler(string itemName, Type expectedHandlerType)
        {
            var item = new Item { Name = itemName };
            var factory = new DailyUpdateItemHandlerFactory();
            var handler = factory.GetHandler(item);
            Assert.IsType(expectedHandlerType, handler);
        }

        [Fact]
        public void GetHandler_NullItem_ThrowsArgumentNullException()
        {
            var factory = new DailyUpdateItemHandlerFactory();
            Assert.Throws<ArgumentNullException>(() => factory.GetHandler(null));
        }
    }
}