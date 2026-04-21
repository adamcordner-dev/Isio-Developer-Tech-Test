using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly ItemUpdaterFactory _itemUpdaterFactory = new ItemUpdaterFactory();
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> Items)
    {
        _items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            IItemUpdater itemUpdater = _itemUpdaterFactory.Create(item);
            itemUpdater.Update(item);
        }
    }
}