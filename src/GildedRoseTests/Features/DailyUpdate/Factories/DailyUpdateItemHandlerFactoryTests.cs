using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Factories;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(AgedBrieHandler))).Returns(new AgedBrieHandler());
            serviceProvider.Setup(x => x.GetService(typeof(LegendaryItemHandler))).Returns(new LegendaryItemHandler());
            serviceProvider.Setup(x => x.GetService(typeof(BackstagePassHandler))).Returns(new BackstagePassHandler());
            serviceProvider.Setup(x => x.GetService(typeof(ConjuredItemHandler))).Returns(new ConjuredItemHandler());
            serviceProvider.Setup(x => x.GetService(typeof(NormalItemHandler))).Returns(new NormalItemHandler());
            var factory = new DailyUpdateItemHandlerFactory(serviceProvider.Object);
            var handler = factory.GetHandler(item);
            Assert.IsType(expectedHandlerType, handler);
        }

        [Fact]
        public void GetHandler_NullItem_ThrowsArgumentNullException()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            var factory = new DailyUpdateItemHandlerFactory(serviceProvider.Object);
            Assert.Throws<ArgumentNullException>(() => factory.GetHandler(null));
        }
    }
}