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

                switch (item.Name) {
                    case "Aged Brie":
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    case "Conjured Mana Cake":
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
                        break;
                }
            }


            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Conjured Mana Cake")
                {

                    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;

                            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].SellIn < 11)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }

                                if (Items[i].SellIn < 6)
                                {
                                    if (Items[i].Quality < 50)
                                    {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }
                            }
                        }
                    }

                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].SellIn = Items[i].SellIn - 1;
                    }

                    if (Items[i].SellIn < 0)
                    {
                        if (Items[i].Name != "Aged Brie")
                        {
                            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].Quality > 0)
                                {
if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                    {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - Items[i].Quality;
                            }
                        }
                        else
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
