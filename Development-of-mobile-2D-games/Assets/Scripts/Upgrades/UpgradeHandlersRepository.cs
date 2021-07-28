using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandlersRepository : IRepository<int, IUpgradeHandler>
{
    private Dictionary<int, IUpgradeHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeHandler>();


    public IReadOnlyDictionary<int, IUpgradeHandler> Collection => _upgradeItemsMapById;

    public UpgradeHandlersRepository(List<UpgradeItemConfig> upgradeItemConfigs)
    {
        PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
    }


    private void PopulateItems(ref Dictionary<int, IUpgradeHandler> upgradeHandlersMapByType,
        List<UpgradeItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
            upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
        }
    }

    private IUpgradeHandler CreateHandlerByType(UpgradeItemConfig config)
    {
        switch (config.UpgradeType)
        {
            case UpgradeType.Speed:
                return new SpeedUpgradeCarHandler(config.ValueUpgrade);
            default: 
                return StubUpgradeCarHandler.Default;


        }
    }
}
