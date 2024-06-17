using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata;

namespace GildedRoseKata.Features.DailyUpdate.Factories.Interfaces
{
    /// <summary>
    /// Factory interface for retrieving handlers that update items daily
    /// </summary>
    public interface IDailyUpdateItemHandlerFactory
    {
        /// <summary>
        /// Gets the handler matching the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>A handler for the item.</returns>
        public IUpdateItemHandler GetHandler(Item item);
    }
}