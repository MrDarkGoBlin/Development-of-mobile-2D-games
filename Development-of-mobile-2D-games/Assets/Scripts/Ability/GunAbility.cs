using JetBrains.Annotations;
using System;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

public class GunAbility : IAbility
{
    private readonly AbilityItemConfig _config;

    public GunAbility([NotNull]AbilityItemConfig config)
    {
        _config = config;
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = Object.Instantiate(_config.view).GetComponent<Rigidbody2D>();
        projectile.AddForce(activator.GetViewObject().transform.right * _config.value, ForceMode2D.Force);
    }

    public void Init(AbilitiesController abilitiesController, ButtonAbility buttonAbility)
    {
        
    }
}
