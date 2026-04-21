using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class ConjuredItemUpdaterTests
    {
        [Fact]
        public void ConjuredItemUpdater_Update_ShouldDecreaseQualityBy2BeforeExpiry()
        {
            Item item = new Item { Name = "Conjured Item", SellIn = 5, Quality = 10 };
            ConjuredItemUpdater conjuredItemUpdater = new ConjuredItemUpdater();

            conjuredItemUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void ConjuredItemUpdater_Update_ShouldDecreaseQualityBy4AfterExpiry()
        {
            Item item = new Item { Name = "Conjured Item", SellIn = 0, Quality = 10 };
            ConjuredItemUpdater conjuredItemUpdater = new ConjuredItemUpdater();

            conjuredItemUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(6, item.Quality);
        }

        [Fact]
        public void ConjuredItemUpdater_Update_ShouldNotDecreaseQualityBelowMinimum()
        {
            Item item = new Item { Name = "Conjured Item", SellIn = 5, Quality = 1 };
            ConjuredItemUpdater conjuredItemUpdater = new ConjuredItemUpdater();

            conjuredItemUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}
