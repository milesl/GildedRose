using GildedRoseKata;
using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Constructor_NullFactory_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new GildedRose([], null));
        }

        [Fact]
        public void UpdateQuality_CallsHandlerUpdate_ForEachItem()
        {
            var items = new List<Item>
            {
                new Item { Name = "Item1", SellIn = 10, Quality = 20 },
                new Item { Name = "Item2", SellIn = 5, Quality = 30 }
            };

            var mockHandler1 = new Mock<IUpdateItemHandler>();
            var mockHandler2 = new Mock<IUpdateItemHandler>();
            var mockFactory = new Mock<IDailyUpdateItemHandlerFactory>();
            mockFactory.Setup(f => f.GetHandler(items[0])).Returns(mockHandler1.Object);
            mockFactory.Setup(f => f.GetHandler(items[1])).Returns(mockHandler2.Object);

            var gildedRose = new GildedRose(items, mockFactory.Object);
            gildedRose.UpdateQuality();

            mockHandler1.Verify(h => h.Update(items[0]), Times.Once);
            mockHandler2.Verify(h => h.Update(items[1]), Times.Once);
        }

        [Fact]
        public void UpdateQuality_NoItems_NoHandlerCalls()
        {
            var items = new List<Item>();
            var mockFactory = new Mock<IDailyUpdateItemHandlerFactory>();

            var gildedRose = new GildedRose(items, mockFactory.Object);

            gildedRose.UpdateQuality();

            mockFactory.Verify(f => f.GetHandler(It.IsAny<Item>()), Times.Never);
        }
    }
}