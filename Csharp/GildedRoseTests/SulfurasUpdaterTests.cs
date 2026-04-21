using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class SulfurasUpdaterTests
    {
        [Fact]
        public void SulfurasUpdater_Update_ShouldNotUpdateSellInOrQuality()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            SulfurasUpdater sulfurasUpdater = new SulfurasUpdater();

            sulfurasUpdater.Update(item);

            Assert.Equal(10, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
