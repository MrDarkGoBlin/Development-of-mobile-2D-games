public class StubUpgradeCarHandler : IUpgradeHandler
{
    public static readonly IUpgradeHandler Default = new StubUpgradeCarHandler();

    public IUpgradable Upgrade(IUpgradable upgradableCar)
    {
        return upgradableCar;
    }
}
