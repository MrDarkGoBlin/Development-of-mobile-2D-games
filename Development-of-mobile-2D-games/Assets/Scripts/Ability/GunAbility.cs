using JetBrains.Annotations;
using System;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

public class GunAbility : IAbility
{
    private readonly Rigidbody2D _viewPrefab;
    private readonly float _projectileSpeed;

    public GunAbility(
        [NotNull] string viewPath,
        AbilityItemConfig abilityItemConfig
        )
    {
        var ability =  ResourceLoader.LoadPrefabs(new ResourcePath { PathResource = viewPath });
        _viewPrefab = ability.GetComponent<Rigidbody2D>();
        if (_viewPrefab == null) throw new InvalidOperationException($"{nameof(GunAbility)} view requires {nameof(Rigidbody2D)} component!");
        _projectileSpeed = abilityItemConfig.value;
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = Object.Instantiate(_viewPrefab);
        projectile.AddForce(activator.GetViewObject().transform.right * _projectileSpeed, ForceMode2D.Force);
    }

    public void Init(AbilitiesController abilitiesController, ButtonAbility buttonAbility)
    {
        
    }
}
