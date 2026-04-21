namespace GildedRoseKata
{
    public class ConjuredItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            int qualityUpdate = item.SellIn < 0 ? 4 : 2;
            QualityHelper.DecreaseQuality(item, qualityUpdate);
        }
    }
}
