using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class ItemUpdaterFactoryTests
    {
        [Fact]
        public void ItemUpdaterFactory_Create_ShouldReturnAgedBrieUpdater()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);

            Assert.IsType<AgedBrieUpdater>(itemUpdater);
        }

        [Fact]
        public void ItemUpdaterFactory_Create_ShouldReturnSulfurasUpdater()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 10 };
            ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);

            Assert.IsType<SulfurasUpdater>(itemUpdater);
        }

        [Fact]
        public void ItemUpdaterFactory_Create_ShouldReturnBackstagePassesUpdater()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);

            Assert.IsType<BackstagePassesUpdater>(itemUpdater);
        }

        [Fact]
        public void ItemUpdaterFactory_Create_ShouldReturnConjuredItemUpdater()
        {
            Item item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
            ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);

            Assert.IsType<ConjuredItemUpdater>(itemUpdater);
        }

        [Fact]
        public void ItemUpdaterFactory_Create_ShouldReturnLuxuryItemUpdater()
        {
            Item item = new Item { Name = "Luxury Chocolate", SellIn = 5, Quality = 10 };
            ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);

            Assert.IsType<LuxuryItemUpdater>(itemUpdater);
        }
    }
}
