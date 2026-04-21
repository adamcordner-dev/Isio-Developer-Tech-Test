namespace GildedRoseKata
{
    public class LuxuryItemUpdater : IItemUpdater
    {
        private const int MinimumQuality = 10;

        public void Update(Item item)
        {
            item.SellIn--;
            if (item.Quality > MinimumQuality)
            {
                QualityHelper.DecreaseQuality(item, 1);
            }
        }
    }
}
