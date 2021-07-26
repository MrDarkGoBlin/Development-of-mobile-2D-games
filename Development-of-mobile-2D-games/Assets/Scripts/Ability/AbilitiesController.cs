using JetBrains.Annotations;
using Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

public class AbilitiesController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/AbilitiView" };
    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityRepository _abilityRepository;
    private readonly AbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _abilityActivator;
    private readonly IAbility _accelerationAbility;
    private readonly IAbility _oilAbility;
    private readonly IAbility _cannonAbility;

    public AbilitiesController(
        [NotNull] IAbilityActivator abilityActivator,
        [NotNull] IInventoryModel inventoryModel,
        [NotNull] IAbilityRepository abilityRepository,
        Car car, AbilityItemConfig accelerationAbility,
        AbilityItemConfig oilAbility,
        AbilityItemConfig cannonAbility,
        Transform placeForUI
        )
    {
        _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
        _abilityCollectionView = LoadView(placeForUI);
        _accelerationAbility = new AccelerationAbility(car, accelerationAbility);
        _oilAbility = new OilAbility(oilAbility, car);
        _cannonAbility = new AccelerationAbility(car, cannonAbility);
    }

    

    private AbilityCollectionView LoadView(Transform placeForUI)
    {
        var objectAbilitiesView = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath), placeForUI);
        AddGameObject(objectAbilitiesView);

        return objectAbilitiesView.GetComponent<AbilityCollectionView>();
    }
    public void AbilityInit(AbilitiesController abilitiesController)
    {
        foreach (var item in _abilityCollectionView.ButtonsAbility)
        {
            _accelerationAbility.Init(abilitiesController, item);
        }

    }


    public void AbilityActive(AbilityType abilityID)
    {
        switch (abilityID)
        {
            case AbilityType.None:
                break;
            case AbilityType.Gun:
                _cannonAbility.Apply(_abilityActivator);
                break;
            case AbilityType.Acceleration:
                _accelerationAbility.Apply(_abilityActivator);
                break;
            case AbilityType.Oil:
                _oilAbility.Apply(_abilityActivator);
                break;
            default:
                break;
        }
    }
}
