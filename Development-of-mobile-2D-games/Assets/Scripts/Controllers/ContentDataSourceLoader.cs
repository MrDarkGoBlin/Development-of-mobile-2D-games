using System.Linq;
using System.Collections.Generic;
using Tools;

public static class ContentDataSourceLoader
{
    public static List<UpgradeItemConfig> LoadUpgradeItemConfig(ResourcePath resourcePath)
    {
        //var config = ResourceLoader.LoadPrefabs(resourcePath).GetComponent<UpgradeItemConfigDataSource>();
        var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath); 
        return config == null ? new List<UpgradeItemConfig>() : config.ItemConfigs.ToList();
    }
    public static List<AbilityItemConfig> LoadAbilityItemConfig(ResourcePath resourcePath)
    {
        //var config = ResourceLoader.LoadPrefabs(resourcePath).GetComponent<AbilityItemConfigDataSource>();
        var config = ResourceLoader.LoadObject<AbilityItemConfigDataSource>(resourcePath); 
        return config == null ? new List<AbilityItemConfig>() : config.ItemConfigs.ToList();
    }
}
