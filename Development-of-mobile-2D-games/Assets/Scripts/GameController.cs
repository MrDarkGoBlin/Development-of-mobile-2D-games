using Tools;
using Profile;
using Game.InputLogic;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(ProfilerPlayer profilePlayer, List<AbilityItemConfig> abilityItemConfigs, Transform placeForUi)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();

        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);

        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);

        var carController = new CarController();
        AddController(carController);
        AbilityItemConfig cannonAbility = null;
        AbilityItemConfig accelerationAbility = null; ;
        AbilityItemConfig oilAbility = null; 
        foreach (var item in abilityItemConfigs)
        {
            switch (item.type)
            {
                case AbilityType.None:
                    break;
                case AbilityType.Gun:
                    cannonAbility = item;
                    break;
                case AbilityType.Acceleration:
                    accelerationAbility = item;
                    break;
                case AbilityType.Oil:
                    oilAbility = item;
                    break;
                default:
                    break;;
}
        }

        var abilitiesController = new AbilitiesController(null, null, null, profilePlayer.CurrentCar, accelerationAbility, oilAbility, cannonAbility, placeForUi);
    }
}
