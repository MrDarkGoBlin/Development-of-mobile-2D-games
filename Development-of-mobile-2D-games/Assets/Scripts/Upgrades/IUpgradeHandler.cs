using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradeHandler 
{
    IUpgradable Upgrade(IUpgradable upgradableCar);
}
public interface IUpgradable
{
    float Speed { get; set; }
    void Restore();
}
