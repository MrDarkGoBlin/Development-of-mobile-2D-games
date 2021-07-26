using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Apply(IAbilityActivator activator);

    void Init(AbilitiesController abilitiesController, ButtonAbility buttonAbility);

}
public interface IAbilityActivator
{
    GameObject GetViewObject();
}
public interface IAbilityRepository
{
    IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
}


