using System.Linq;
using System.Collections.Generic;
using Tools;

public static class ContentDataSourceLoader
{
    public static List<UpgradeItemConfig> LoadUpgradeItemConfig(ResourcePath resourcePath)
    {
        var config = ResourceLoader.LoadPrefabs(resourcePath).GetComponent<UpgradeItemConfigDataSource>();
        //var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath);  в методичке указан этот метод
        //я не знаю как это работает, но в методичках(с 1 по 4 занятие) нет LoadObject, так же как и в оставленных вами материалах.
        //и я не понимаю, что он должне делать.
        return config == null ? new List<UpgradeItemConfig>() : config.ItemConfigs.ToList();
    }
    public static List<AbilityItemConfig> LoadAbilityItemConfig(ResourcePath resourcePath)
    {
        var config = ResourceLoader.LoadPrefabs(resourcePath).GetComponent<AbilityItemConfigDataSource>();
        //var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath);  в методичке указан этот метод
        //я не знаю как это работает, но в методичках(с 1 по 4 занятие) нет LoadObject, так же как и в оставленных вами материалах.
        //и я не понимаю, что он должне делать.
        return config == null ? new List<AbilityItemConfig>() : config.ItemConfigs.ToList();
    }
}
