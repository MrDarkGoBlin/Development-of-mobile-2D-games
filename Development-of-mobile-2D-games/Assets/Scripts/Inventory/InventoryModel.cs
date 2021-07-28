using System.Collections.Generic;

public class InventoryModel : IInventoryModel
{
    private readonly IReadOnlyList<IItem> _subCollection = new List<IItem>();
    private readonly List<IItem> _equippedItems = new List<IItem>();

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _equippedItems ?? _subCollection;
    }
    public void EquippedItem(IItem item)
    {
        if (_equippedItems.Contains(item))
            return;

        _equippedItems.Add(item);
    }

    public void UnequippedItem(IItem item)
    {
        if(!_equippedItems.Contains(item))
            return;

        _equippedItems.Remove(item);
    }
}
