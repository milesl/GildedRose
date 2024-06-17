using GildedRoseKata.Features.DailyUpdate.Factories;
using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using GildedRoseKata.Features.OverviewWriters;
using GildedRoseKata.Features.OverviewWriters.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var serviceProvider = new ServiceCollection()
                .AddSingleton<AgedBrieHandler>()
                .AddSingleton<BackstagePassHandler>()
                .AddSingleton<ConjuredItemHandler>()
                .AddSingleton<LegendaryItemHandler>()
                .AddSingleton<NormalItemHandler>()
                .AddSingleton<IDailyUpdateItemHandlerFactory, DailyUpdateItemHandlerFactory>()
                .AddSingleton<IDailyOverviewWriter, DailyOverviewWriter>()
                .AddSingleton(Items)
                .AddSingleton<ICollection<Item>>(Items)
                .AddSingleton<GildedRose>()
                .BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<GildedRose>();
            var dailyWriter = serviceProvider.GetRequiredService<IDailyOverviewWriter>();


            for (var i = 0; i < 31; i++)
            {
                dailyWriter.WriteOverview(i);
                app.UpdateQuality();
            }
        }
    }
}