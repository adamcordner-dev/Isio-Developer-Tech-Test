namespace GildedRoseKata
{
    public class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            int qualityUpdate = item.SellIn < 0 ? 2 : 1;
            QualityHelper.DecreaseQuality(item, qualityUpdate);
        }
    }
}
