namespace GildedRoseKata
{
    public class ItemUpdaterFactory
    {
        public IItemUpdater Create(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieUpdater(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassesUpdater(),
                string name when name.Contains("Conjured") => new ConjuredItemUpdater(),
                string name when name.Contains("Luxury") => new LuxuryItemUpdater(),
                _ => new NormalItemUpdater()
            };
        }
    }
}
