using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> Items)
    {
        _items = Items;
    }

    public void UpdateQuality()
    {
        ItemUpdaterFactory itemUpdaterFactory = new ItemUpdaterFactory();

        foreach (Item item in _items)
        {
            IItemUpdater itemUpdater = itemUpdaterFactory.Create(item);
            itemUpdater.Update(item);
        }
    }
}