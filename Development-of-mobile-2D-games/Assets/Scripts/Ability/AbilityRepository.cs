using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRepository : IRepository<int, IAbility>
{
    private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();

    public AbilityRepository(List<AbilityItemConfig> itemConfigs)
    {
        PopulateItems(ref _abilityMapById, itemConfigs);
    }

    private void PopulateItems(ref Dictionary<int, IAbility> upgradeHandlersMapByType, List<AbilityItemConfig> configs)
    {
        foreach (var config in configs)
        {
            if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
            upgradeHandlersMapByType.Add(config.Id, CreateAbilityByType(config));
        }
    }

    private IAbility CreateAbilityByType(AbilityItemConfig config)
    {
        switch (config.type)
        {
            case AbilityType.None:
                return null;
                break;
            case AbilityType.Gun:
                return new GunAbility(config);
                break;
            case AbilityType.Acceleration:
                return null;
                break;
            case AbilityType.Oil:
                return null;
                break;
            default:
                return null;
                break;
        }
    }
    public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;
}
