using Profile;
using Ui;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer,
        DailyRewardView dailyRewardView, StartFightView startFightView, FightWindowView fightWindowView, CurrencyView currencyView)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        _dailyRewardView = dailyRewardView;
        _startFightView = startFightView;
        _fightWindowView = fightWindowView;
        _currencyView = currencyView;
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private ShedController _shedController;
    private DailyRewardController _dailyRewardController;
    private StartFightController _startFightController;
    private FightWindowController _fightWindowController;

    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly DailyRewardView _dailyRewardView;
    private readonly StartFightView _startFightView;
    private readonly FightWindowView _fightWindowView;
    private readonly CurrencyView _currencyView;

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
                AllClear();
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _startFightController = new StartFightController(_placeForUi, _profilePlayer, _startFightView);
                _startFightController.RefrashView();
                break;

            case GameState.DailyReward:
                AllClear();
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer, _dailyRewardView, _currencyView);
                _dailyRewardController.RefrashView();
                break;

            case GameState.Fight:
                AllClear();
                _fightWindowController = new FightWindowController(_placeForUi, _profilePlayer, _fightWindowView);
                _fightWindowController.RefreshView();
                break;

            default:
                AllClear();
                break;
        }
    }

    private void AllClear()
    {
        _shedController?.Dispose();
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _fightWindowController?.Dispose();
        _startFightController?.Dispose();
        _dailyRewardController?.Dispose();
    }
}
