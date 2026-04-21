using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class BackstagePassesUpdaterTests
    {
        [Fact]
        public void BackstagePassesUpdater_Update_ShouldIncreaseQualityBy1WhenSellInGreaterThan7()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            BackstagePassesUpdater backstagePassesUpdater = new BackstagePassesUpdater();

            backstagePassesUpdater.Update(item);

            Assert.Equal(9, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void BackstagePassesUpdater_Update_ShouldIncreaseQualityBy3WhenSell7OrLess()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 };
            BackstagePassesUpdater backstagePassesUpdater = new BackstagePassesUpdater();

            backstagePassesUpdater.Update(item);

            Assert.Equal(6, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void BackstagePassesUpdater_Update_ShouldIncreaseQualityBy4WhenSellIn2OrLess()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 };
            BackstagePassesUpdater backstagePassesUpdater = new BackstagePassesUpdater();

            backstagePassesUpdater.Update(item);

            Assert.Equal(1, item.SellIn);
            Assert.Equal(24, item.Quality);
        }

        [Fact]
        public void BackstagePassesUpdater_Update_ShouldDecreaseQualityTo0AfterExpiry()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            BackstagePassesUpdater backstagePassesUpdater = new BackstagePassesUpdater();

            backstagePassesUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void BackstagePassesUpdater_Update_ShouldNotIncreaseQualityAboveMaximum()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 39 };
            BackstagePassesUpdater backstagePassesUpdater = new BackstagePassesUpdater();

            backstagePassesUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(40, item.Quality);
        }
    }
}
