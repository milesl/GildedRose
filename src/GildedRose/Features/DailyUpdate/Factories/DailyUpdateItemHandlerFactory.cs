using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata;

namespace GildedRoseKata.Features.DailyUpdate.Factories
{
    /// <summary>
    /// Implementation of daily update item handler factory
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.DailyUpdate.Factories.Interfaces.IDailyUpdateItemHandlerFactory" />
    public class DailyUpdateItemHandlerFactory : IDailyUpdateItemHandlerFactory
    {
        /// <summary>
        /// Gets the handler matching the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// A handler for the item.
        /// </returns>
        /// <remarks>
        /// Initial implementation is fixed to name.
        /// </remarks>
        public IUpdateItemHandler GetHandler(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieHandler();

                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryItemHandler();

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassHandler();

                case "Conjured Mana Cake":
                    return new ConjuredItemHandler();

                default:
                    return new NormalItemHandler();
            }
        }
    }
}