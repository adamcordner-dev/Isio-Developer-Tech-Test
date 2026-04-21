using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class QualityHelperTests
    {
        [Fact]
        public void QualityHelper_IncreaseQuality_ShouldNotIncreaseQualityAboveMaximum()
        {
            Item item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 39 };

            QualityHelper.IncreaseQuality(item, 2);

            Assert.Equal(40, item.Quality);
        }

        [Fact]
        public void QualityHelper_IncreaseQuality_ShouldNotDecreaseQualityBelowMinimum()
        {
            Item item = new Item { Name = "Normal Item", SellIn = 5, Quality = 1 };

            QualityHelper.DecreaseQuality(item, 2);

            Assert.Equal(0, item.Quality);
        }
    }
}
