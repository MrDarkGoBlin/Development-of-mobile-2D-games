public class SpeedUpgradeCarHandler : IUpgradeHandler
{
    private readonly float _speed;

    public SpeedUpgradeCarHandler(float speed)
    {
        _speed = speed;
    }
    public IUpgradable Upgrade(IUpgradable upgradableCar)
    {
        upgradableCar.Speed = _speed;
        return upgradableCar;
    }
}
