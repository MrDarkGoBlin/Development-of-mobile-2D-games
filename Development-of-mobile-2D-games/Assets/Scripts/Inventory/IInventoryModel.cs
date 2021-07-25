using System.Collections.Generic;

public interface IInventoryModel
{
    List<IItem> GetEquippedItems();
    void EquippedItem(IItem item);
    void UnEquippedItem(IItem item);
}
