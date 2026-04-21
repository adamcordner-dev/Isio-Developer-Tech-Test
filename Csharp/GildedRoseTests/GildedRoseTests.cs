using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void GildedRose_UpdateQuality_ShouldProcessMultipleItemsCorrectly()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 10 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        GildedRose gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(9, Items[0].Quality);
        Assert.Equal(1, Items[1].SellIn);
        Assert.Equal(1, Items[1].Quality);
        Assert.Equal(0, Items[2].SellIn);
        Assert.Equal(80, Items[2].Quality);
    }

    [Fact]
    public void GildedRose_UpdateQuality_ShouldNeverDecreaseQualityBelowMinimum()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Normal Item", SellIn = 5, Quality = 0 },
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 1 }
        };
        GildedRose gildedRose = new GildedRose(Items);

        gildedRose.UpdateQuality();

        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
        Assert.Equal(2, Items[1].SellIn);
        Assert.Equal(0, Items[1].Quality);
    }

    [Fact]
    public void GildedRose_UpdateQuality_ShouldNeverIncreaseQualityAboveMaximum()
    {
        IList<Item> Items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 40 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 39 }
        };
        GildedRose gildedRose = new GildedRose(Items);
        gildedRose.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(40, Items[0].Quality);
        Assert.Equal(4, Items[1].SellIn);
        Assert.Equal(40, Items[1].Quality);
    }
}