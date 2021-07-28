using System;
using System.Collections.Generic;

public interface IInventoryController 
{
    IReadOnlyList<IItem> GetEqueppendItems();
    void ShowInventory(Action hideAction);

    void HideInventory();
}

