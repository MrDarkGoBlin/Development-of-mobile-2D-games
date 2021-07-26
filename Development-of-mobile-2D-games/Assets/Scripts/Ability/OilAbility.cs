using JoostenProductions;
using Profile;
using UnityEngine;

public class OilAbility : IAbility
{
    private Car _car;
    private AbilityItemConfig _abilityItemConfig;
    private Vector3 _move;
    private float _timeToDeath;
    private GameObject _ablilityObject; // сделать отдельный клас для viewAbility


    public OilAbility(AbilityItemConfig abilityItemConfig, Car car)
    {
        _timeToDeath = abilityItemConfig.value;
        _car = car;
    }
    public void Init(AbilitiesController abilitiesController, ButtonAbility buttonAbility)
    {
        buttonAbility.Init(_abilityItemConfig.type, abilitiesController, _abilityItemConfig.imageAbility);
    }
    public void Apply(IAbilityActivator activator)
    {
        _ablilityObject = Object.Instantiate(_abilityItemConfig.view, activator.GetViewObject().transform);
        UpdateManager.SubscribeToUpdate(TimerToDeath);
        _move = activator.GetViewObject().transform.position;
    }

    private void TimerToDeath()
    {
        if (_timeToDeath <= 0)
        {           
            UpdateManager.UnsubscribeFromUpdate(TimerToDeath);
        }
        _timeToDeath -= Time.deltaTime;
        _move.x -= _car.Speed;
        _ablilityObject.transform.position = _move;
    }
}
