using System.Collections.Generic;

public interface IInventoryModel
{
    IReadOnlyList<IItem> GetEquippedItems();
    void EquippedItem(IItem item);
    void UnequippedItem(IItem item);
}
