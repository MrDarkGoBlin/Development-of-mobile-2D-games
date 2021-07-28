using Tools;
using Profile;
using Game.InputLogic;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();
        var tapeBackgroundController =
            new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);
        var inputGameController =
            new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);
        var carController = new CarController();
        AddController(carController);

        // можно внедрить как зависимость для другого контроллера
        var abilityController = ConfigureAbilityController(placeForUi, carController);
    }

    private IAbilitiesController ConfigureAbilityController(
           Transform placeForUi,
           IAbilityActivator abilityActivator)
    {
        var abilityItemsConfigCollection
            = ContentDataSourceLoader.LoadAbilityItemConfig(new ResourcePath { PathResource = "DataSource/Ability/AbilityItemConfigDataSource" });
        var abilityRepository
            = new AbilityRepository(abilityItemsConfigCollection);
        var abilityCollectionViewPath
            = new ResourcePath { PathResource = $"Prefabs/{nameof(AbilityCollectionView)}" };
        var abilityCollectionView
            = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
        AddGameObject(abilityCollectionView.gameObject);

        // загрузить в модель экипированные предметы можно любым способом
        var inventoryModel = new InventoryModel();
        var abilitiesController = new AbilitiesController(abilityRepository, inventoryModel, abilityCollectionView, abilityActivator);
        AddController(abilitiesController);

        return abilitiesController;
    }

}
