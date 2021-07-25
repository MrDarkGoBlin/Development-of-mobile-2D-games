using JetBrains.Annotations;
using System;
using System.Collections.Generic;

public class InventoryController : BaseController, IInvetnoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly IItemsRepository _itemsRepository;

    public InventoryController(
       [NotNull] IInventoryModel inventoryModel,
       [NotNull] IItemsRepository itemsRepository,
       [NotNull] IInventoryView inventoryView
        )
    {
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

    }



    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquippedItem(item);

        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }
    public void HideInventory()
    {
        
    }
}
