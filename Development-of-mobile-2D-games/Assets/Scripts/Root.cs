﻿using Profile;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
    private UnityAdsTools _unityAdsTools;

    [SerializeField]
    private List<ItemConfig> _itemsConfig;
    [SerializeField]
    private List<UpgradeItemConfig> _upgradeItemsConfig;
    [SerializeField]
    private List<AbilityItemConfig> _abilityItemsConfig;

    private MainController _mainController;

    private void Awake()
    {
        _unityAdsTools = new UnityAdsTools();
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
