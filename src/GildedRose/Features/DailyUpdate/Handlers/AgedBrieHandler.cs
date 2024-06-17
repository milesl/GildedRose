﻿using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using System;

namespace GildedRoseKata.Features.DailyUpdate.Handlers
{
    /// <summary>
    /// Handles updates for aged brie
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces.IUpdateItemHandler" />
    public class AgedBrieHandler : IUpdateItemHandler
    {
        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentNullException">item</exception>

        public void Update(Item item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            item.Quality = item.Quality < 50 ? item.Quality + 1 : 50;
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality < 50 ? item.Quality + 1 : 50;
            }
        }
    }
}