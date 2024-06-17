using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata;
using System;

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
        /// <exception cref="System.ArgumentNullException">item</exception>
        public void Update(Item item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (item.Quality == 1)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality = item.Quality > 0 ? item.Quality - 2 : 0;
            }
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                if (item.Quality == 1)
                {
                    item.Quality = 0;
                }
                else
                {
                    item.Quality = item.Quality > 0 ? item.Quality - 2 : 0;
                }
            }
        }
    }
}