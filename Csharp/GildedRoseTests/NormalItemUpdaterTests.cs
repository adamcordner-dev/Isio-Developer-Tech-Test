using Xunit;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class NormalItemUpdaterTests
    {
        [Fact]
        public void NormalItemUpdater_Update_ShouldDecreaseQualityBy1BeforeExpiry()
        {
            Item item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
            NormalItemUpdater normalItemUpdater = new NormalItemUpdater();

            normalItemUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void NormalItemUpdater_Update_ShouldDecreaseQualityBy2AfterExpiry()
        {
            Item item = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
            NormalItemUpdater normalItemUpdater = new NormalItemUpdater();

            normalItemUpdater.Update(item);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void NormalItemUpdater_Update_ShouldNotDecreaseQualityBelow0()
        {
            Item item = new Item { Name = "Normal Item", SellIn = 5, Quality = 0 };
            NormalItemUpdater normalItemUpdater = new NormalItemUpdater();

            normalItemUpdater.Update(item);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void NormalItemUpdater_Update_ShouldDecreaseSellAndQuantityInEachDay()
        {
            Item item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
            NormalItemUpdater normalItemUpdater = new NormalItemUpdater();

            for (int i = 0; i < 5; i++)
            {
                normalItemUpdater.Update(item);
            }

            Assert.Equal(0, item.SellIn);
            Assert.Equal(5, item.Quality);
        }
    }
}
