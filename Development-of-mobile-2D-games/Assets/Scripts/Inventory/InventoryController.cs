using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IInventoryView _inventoryView;
    private readonly IRepository<int, IItem> _itemsRepository;
    private Action _hideAction;

    public InventoryController(
       [NotNull] IInventoryModel inventoryModel,
       [NotNull] IRepository<int, IItem> itemsRepository,
       [NotNull] IInventoryView inventoryView
        )
    {
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));

    }

    protected override void OnDispose()
    {
        CleanupView();
        base.OnDispose();
    }

    public IReadOnlyList<IItem> GetEqueppendItems()
    {
        return _inventoryModel.GetEquippedItems();
    }

    public void ShowInventory(Action hideAction)
    {
        _hideAction = hideAction;
        _inventoryView.Show();
        _inventoryView.Display(_itemsRepository.Collection.Values.ToList());
    }
    public void HideInventory()
    {
        _inventoryView.Hide();
        _hideAction?.Invoke();
    }

    private void SetupView(IInventoryView inventoryView)
    {
        inventoryView.Selected += OnItemSelected;
        inventoryView.Deselected += OnItemDeSelected;
    }

    private void CleanupView() 
    {
        _inventoryView.Selected -= OnItemSelected;
        _inventoryView.Deselected -= OnItemDeSelected;
    }

    private void OnItemSelected(object sender, IItem item)
    {
        _inventoryModel.EquippedItem(item);
    }
    private void OnItemDeSelected(object sender, IItem item)
    {
        _inventoryModel.UnequippedItem(item);
    }

}
