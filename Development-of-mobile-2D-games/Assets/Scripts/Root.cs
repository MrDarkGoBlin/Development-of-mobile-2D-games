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

    private MainController _mainController;

    private void Awake()
    {
        _unityAdsTools = new UnityAdsTools();
        var profilePlayer = new ProfilerPlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _itemsConfig, _upgradeItemsConfig);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
