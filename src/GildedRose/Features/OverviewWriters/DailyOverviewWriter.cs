using GildedRoseKata.Features.OverviewWriters.Interface;
using System;
using System.Collections.Generic;

namespace GildedRoseKata.Features.OverviewWriters
{
    /// <summary>
    /// Writes the daily overview
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.OverviewWriters.Interface.IDailyOverviewWriter" />
    public class DailyOverviewWriter : IDailyOverviewWriter
    {
        private readonly ICollection<Item> items;

        public DailyOverviewWriter(ICollection<Item> items)
        {
            ArgumentNullException.ThrowIfNull(items, nameof(items));
            this.items = items;
        }

        /// <summary>
        /// Writes the overview.
        /// </summary>
        /// <param name="day">The day.</param>
        public void WriteOverview(int day)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in this.items)
            {
                System.Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            Console.WriteLine("");
        }
    }
}