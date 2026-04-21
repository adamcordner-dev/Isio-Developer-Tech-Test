namespace GildedRoseKata
{
    public class BackstagePassesUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }
            int qualityIncrease = item.SellIn < 3 ? 4 : item.SellIn < 7 ? 3 : 1;
            QualityHelper.IncreaseQuality(item, qualityIncrease);
        }
    }
}
