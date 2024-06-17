using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata;

namespace GildedRoseKata.Features.DailyUpdate.Handlers
{
    /// <summary>
    /// Handler for updating conjured items.
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces.IUpdateItemHandler" />
    public class ConjuredItemHandler : IUpdateItemHandler
    {
        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Update(Item item)
        {
            item.Quality = item.Quality > 0 ? item.Quality - 2 : 0;
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality > 0 ? item.Quality - 2 : 0;
            }
        }
    }
}