namespace GildedRoseKata
{
    public class LuxuryItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            if (item.Quality > 10)
            {
                QualityHelper.DecreaseQuality(item, 1);
            }
            if (item.Quality < 10)
            {
                item.Quality = 10;
            }
        }
    }
}
