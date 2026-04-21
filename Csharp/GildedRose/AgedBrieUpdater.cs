namespace GildedRoseKata
{
    public class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            int qualityUpdate = item.SellIn < 0 ? 2 : 1;
            QualityHelper.IncreaseQuality(item, qualityUpdate);
        }
    }
}
