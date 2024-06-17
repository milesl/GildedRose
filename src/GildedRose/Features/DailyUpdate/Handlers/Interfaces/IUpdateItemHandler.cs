using GildedRoseKata;

namespace GildedRoseKata.Features.DailyUpdate.Handlers.Interfaces
{
    /// <summary>
    /// Interface for the update item handler.
    /// </summary>
    public interface IUpdateItemHandler
    {
        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Update(Item item);
    }
}