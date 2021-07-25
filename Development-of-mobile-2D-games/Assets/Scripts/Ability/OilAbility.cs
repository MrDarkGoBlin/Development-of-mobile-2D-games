using JoostenProductions;
using Profile;
using UnityEngine;

public class OilAbility : IAbility
{
    private readonly GameObject _view; //необходимо сделать префаб масла
    private Car _car;
    private Vector3 _move;
    private float _timeToDeath;


    public OilAbility(AbilityItemConfig abilityItemConfig, Car car)
    {
        _timeToDeath = abilityItemConfig.value;
        _view = abilityItemConfig.view;
        _car = car;
    }
    public void Apply(IAbilityActivator activator)
    {
        var objectOil = Object.Instantiate(_view, activator.GetViewObject().transform);
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
        _view.transform.position = _move;
    }
}
