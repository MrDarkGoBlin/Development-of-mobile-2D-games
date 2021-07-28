using JetBrains.Annotations;
using Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

public class AbilitiesController : BaseController , IAbilitiesController
{
    //private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/AbilitiView" };
    //private readonly IInventoryModel _inventoryModel;
    //private readonly IAbilityRepository _abilityRepository;
    //private readonly AbilityCollectionView _abilityCollectionView;
    //private readonly IAbilityActivator _abilityActivator;
    //private readonly IAbility _accelerationAbility;
    //private readonly IAbility _oilAbility;
    //private readonly IAbility _cannonAbility;
    private readonly IRepository<int, IAbility> _abilityRepository;
    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityCollectionView _abilityCollectionView;
    private readonly IAbilityActivator _carController;

    public AbilitiesController(
        [NotNull] IRepository<int, IAbility> abilityRepository,
        [NotNull] IInventoryModel inventoryModel,
        [NotNull] IAbilityCollectionView abilityCollectionView,
        [NotNull] IAbilityActivator abilityActivator)
    {
        _carController = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
        _abilityCollectionView = abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));

        SetupView(_abilityCollectionView);

    }

    private void SetupView(IAbilityCollectionView view)
    {
        view.UseRequested += OnAbilityUseRequested;
    }
    private void CleanupView(AbilityCollectionView view)
    {
        view.UseRequested -= OnAbilityUseRequested;
    }

    private void OnAbilityUseRequested(object sender, IItem e)
    {
        if (_abilityRepository.Collection.TryGetValue(e.Id, out var ability))
        {
            ability.Apply(_carController);
        }

    }
       
    public void ShowAbilities()
    {
        _abilityCollectionView.Show();
        _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
    }
}
