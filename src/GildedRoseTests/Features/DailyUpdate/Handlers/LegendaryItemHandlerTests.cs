using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Xunit;

namespace GildedRoseTests.Features.DailyUpdate.Handlers
{
    public class LegendaryItemHandlerTests
    {
        [Fact]
        public void Update_DoesNotChangeQuality()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var handler = new LegendaryItemHandler();
            handler.Update(item);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void Update_DoesNotChangeSellIn()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var handler = new LegendaryItemHandler();
            handler.Update(item);
            Assert.Equal(10, item.SellIn);
        }

        [Fact]
        public void Update_NullItem_DoesNotThrowException()
        {
            var handler = new LegendaryItemHandler();
            var exception = Record.Exception(() => handler.Update(null));
            Assert.Null(exception);
        }
    }
}
