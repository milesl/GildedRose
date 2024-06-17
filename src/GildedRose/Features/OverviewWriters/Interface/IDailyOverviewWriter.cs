using System.Collections.Generic;

namespace GildedRoseKata.Features.OverviewWriters.Interface
{
    /// <summary>
    /// Writes the daily overview
    /// </summary>
    internal interface IDailyOverviewWriter
    {
        /// <summary>
        /// Writes the overview.
        /// </summary>
        /// <param name="day">The day.</param>
        void WriteOverview(int day);
    }
}