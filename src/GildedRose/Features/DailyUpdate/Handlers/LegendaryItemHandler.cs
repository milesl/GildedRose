using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata;
using System;

namespace GildedRoseKata.Features.DailyUpdate.Handlers
{
    /// <summary>
    /// Handles updates for legendary items.
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces.IUpdateItemHandler" />
    public class LegendaryItemHandler : IUpdateItemHandler
    {
        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Update(Item item)
        {
            // Legendary items have no updates
        }
    }
}