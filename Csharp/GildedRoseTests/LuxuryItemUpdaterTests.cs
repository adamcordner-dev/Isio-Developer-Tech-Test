using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class LuxuryItemUpdaterTests
    {
        [Fact]
        public void LuxuryItemUpdater_Update_ShouldDecreaseQualityBy1WhenSellInAboveMinimum()
        {
            Item item = new Item { Name = "Luxury Item", SellIn = 15, Quality = 20 };
            LuxuryItemUpdater luxuryItemUpdater = new LuxuryItemUpdater();

            luxuryItemUpdater.Update(item);

            Assert.Equal(14, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void LuxuryItemUpdater_Update_ShouldNotDecreaseQualityBelowMinimum()
        {
            Item item = new Item { Name = "Luxury Item", SellIn = 15, Quality = 10 };
            LuxuryItemUpdater luxuryItemUpdater = new LuxuryItemUpdater();

            luxuryItemUpdater.Update(item);

            Assert.Equal(14, item.SellIn);
            Assert.Equal(10, item.Quality);
        }
    }
}
