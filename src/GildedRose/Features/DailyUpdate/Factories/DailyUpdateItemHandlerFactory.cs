using GildedRoseKata.Features.DailyUpdate.Factories.Interfaces;
using GildedRoseKata.Features.DailyUpdate.Handlers;
using GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRoseKata.Features.DailyUpdate.Factories
{
    /// <summary>
    /// Implementation of daily update item handler factory
    /// </summary>
    /// <seealso cref="GildedRoseKata.Features.DailyUpdate.Factories.Interfaces.IDailyUpdateItemHandlerFactory" />
    public class DailyUpdateItemHandlerFactory : IDailyUpdateItemHandlerFactory
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DailyUpdateItemHandlerFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public DailyUpdateItemHandlerFactory(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the handler matching the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// A handler for the item.
        /// </returns>
        /// <remarks>
        /// Initial implementation is fixed to name.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">item</exception>
        public IUpdateItemHandler GetHandler(Item item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            return item.Name switch
            {
                "Aged Brie" => this.serviceProvider.GetRequiredService<AgedBrieHandler>(),
                "Sulfuras, Hand of Ragnaros" => this.serviceProvider.GetRequiredService<LegendaryItemHandler>(),
                "Backstage passes to a TAFKAL80ETC concert" => this.serviceProvider.GetRequiredService<BackstagePassHandler>(),
                "Conjured Mana Cake" => this.serviceProvider.GetRequiredService<ConjuredItemHandler>(),
                _ => this.serviceProvider.GetRequiredService<NormalItemHandler>(),
            };
        }
    }
}