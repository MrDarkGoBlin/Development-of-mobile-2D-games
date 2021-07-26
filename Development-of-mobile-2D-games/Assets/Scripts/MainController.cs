using Profile;
using Ui;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilerPlayer profilePlayer, List<ItemConfig> itemsConfig,
        List<UpgradeItemConfig> upgradeItemsConfig, List<AbilityItemConfig> abilityItemsConfig)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _itemsConfig = itemsConfig;
        _upgradeItemsConfig = upgradeItemsConfig;
        _abilityItemsConfig = abilityItemsConfig;
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private ShedController _shedController;
    private readonly Transform _placeForUi;
    private readonly ProfilerPlayer _profilePlayer;
    private readonly List<ItemConfig> _itemsConfig;
    private readonly List<UpgradeItemConfig> _upgradeItemsConfig;
    private readonly List<AbilityItemConfig> _abilityItemsConfig;

    protected override void OnDispose()
    {
        AllClear();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                break;
            case GameState.Game:
               // _shedController = new ShedController(_upgradeItemsConfig, _profilePlayer.CurrentCar);

                _gameController = new GameController(_profilePlayer, _abilityItemsConfig, _placeForUi);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }

    private void AllClear()
    {
        _shedController?.Dispose();
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
    }
}
