using System.Collections.Generic;

public class InventoryModel : IInventoryModel
{
    private readonly List<IItem> _items = new List<IItem>();

    public List<IItem> GetEquippedItems()
    {
        return _items;
    }
    public void EquippedItem(IItem item)
    {
        if (_items.Contains(item))
            return;

        _items.Add(item);
    }

    public void UnEquippedItem(IItem item)
    {
        if(!_items.Contains(item))
            return;

        _items.Remove(item);
    }
}
