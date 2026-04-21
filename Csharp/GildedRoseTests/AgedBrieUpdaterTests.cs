using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class AgedBrieUpdaterTests
    {
        [Fact]
        public void AgedBrieUpdater_Update_ShouldIncreaseQualityBy1BeforeExpiry()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            AgedBrieUpdater agedBrieUpdater = new AgedBrieUpdater();

            agedBrieUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void AgedBrieUpdater_Update_ShouldIncreaseQualityBy2AfterExpiry()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 };
            AgedBrieUpdater agedBrieUpdater = new AgedBrieUpdater();

            agedBrieUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void AgedBrieUpdater_Update_ShouldNotIncreaseQualityAboveMaximum()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 };
            AgedBrieUpdater agedBrieUpdater = new AgedBrieUpdater();

            agedBrieUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(40, item.Quality);
        }
    }
}
