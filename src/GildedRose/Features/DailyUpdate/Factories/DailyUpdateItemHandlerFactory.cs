using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using System;

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
        /// <exception cref="System.ArgumentNullException">item</exception>
        public IUpdateItemHandler GetHandler(Item item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            return item.Name switch
            {
                "Aged Brie" => new AgedBrieHandler(),
                "Sulfuras, Hand of Ragnaros" => new LegendaryItemHandler(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassHandler(),
                "Conjured Mana Cake" => new ConjuredItemHandler(),
                _ => new NormalItemHandler(),
            };
        }
    }
}