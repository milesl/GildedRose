using GildedRoseKata.Features.DailyUpdate.Factories;
using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        /// <summary>
        /// The daily update item handler factory
        /// </summary>
        /// <remarks>Ideally replace with injected version removing knowledge of concrete implementation.</remarks>
        private IDailyUpdateItemHandlerFactory dailyUpdateItemHandlerFactory = new DailyUpdateItemHandlerFactory();

        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        /// <summary>
        /// Processes updates across all items
        /// </summary>
        /// <remarks>
        /// Steps taken to refactor:
        /// 1. Add in Conjured Mana Cake requirement inline with existing approach
        /// 2. Restructure within existing method to reserve != logic as this increase cognitive load and break into logical chunks per item, changed to foreach to reduce index tracking
        /// 3. Refactored to factory pattern within feature folder for daily update
        /// </remarks>
        public void UpdateQuality()
        {
            foreach (var item in this.Items)
            {
                var handler = this.dailyUpdateItemHandlerFactory.GetHandler(item);
                handler.Update(item);
            }
        }
    }
}