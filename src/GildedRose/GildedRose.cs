using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
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
        /// </remarks>
        public void UpdateQuality()
        {
            foreach (var item in this.Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                        item.SellIn -= 1;
                        if (item.SellIn < 0 && item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                            if (item.SellIn < 11 && item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                        item.SellIn -= 1;
                        if (item.SellIn < 0)
                        {
                            item.Quality = 0;
                        }
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        // Legendary Item - do nothing
                        break;
                    case "Conjured Mana Cake":
                        // Degrades twice as fast, doubles after sell by
                        if (item.Quality > 0)
                        {
                            if (item.SellIn < 0)
                            {
                                item.Quality -= 4;
                            }
                            else
                            {
                                item.Quality -= 2;
                            }
                        }
                        item.SellIn -= 1;
                        break;
                    default:
                        if (item.Quality > 0)
                        {
                            item.Quality -= 1;
                        }
                        item.SellIn -= 1;
                        break;
                }
            }
        }
    }
}
