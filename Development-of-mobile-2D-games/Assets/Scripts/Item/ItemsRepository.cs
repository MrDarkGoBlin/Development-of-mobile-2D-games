using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRepository : BaseController, IRepository<int, IItem>
{

    public IReadOnlyDictionary<int, IItem> Collection => _itemsMapById;

    private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

    public ItemsRepository(List<ItemConfig> itemConfigs)
    {
        PopulateItems(itemConfigs);
    }

    protected override void OnDispose()
    {
        _itemsMapById.Clear();

        base.OnDispose();
    }

    private void PopulateItems(List<ItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (_itemsMapById.ContainsKey(config.Id))
                continue;

            _itemsMapById.Add(config.Id, CreateItem(config));

        }
    }
    private IItem CreateItem(ItemConfig config)
    {
        return new Item
        {
            Id = config.Id,
            Info = new ItemInfo { Title = config.Title }
        };
    }


    
}
