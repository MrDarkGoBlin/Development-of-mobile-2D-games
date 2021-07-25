using JoostenProductions;
using Profile;
using UnityEngine;

public class AccelerationAbility : IAbility
{
    private Car _car;
    private float _speed;
    private float _timeToDeath;
    public AccelerationAbility(Car car, AbilityItemConfig abilityItemConfig)
    {
        if (abilityItemConfig.type != AbilityType.Acceleration)
            return;

        _car = car;        
        _speed = abilityItemConfig.value;
    }
    public void Apply(IAbilityActivator activator)
    {
        _car.Speed = _speed;
        UpdateManager.SubscribeToUpdate(TimerToDeath);
        _timeToDeath = 5;//в абилке мы сделали только один параметр, по этому пока делаю так
    }

    private void TimerToDeath()
    {
        if (_timeToDeath <= 0)
        {
            _car.Restore();
            UpdateManager.UnsubscribeFromUpdate(TimerToDeath);
        }
        _timeToDeath -= Time.deltaTime;
    }
}
