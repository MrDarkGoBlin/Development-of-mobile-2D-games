using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/MainMenu" };
    private readonly PlayerProfiler _playerProfiler;
    private readonly MainMenuView _mainMenuView;

    public MainMenuController(Transform placeForUI, PlayerProfiler playerProfiler)
    {
        _playerProfiler = playerProfiler;
        _mainMenuView = LoadView(placeForUI);

        _mainMenuView.ButtonStart.onClick.AddListener(StartGame);
    }

    private MainMenuView LoadView(Transform placeForUI)
    {
        var objectMainMenu = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath), placeForUI);
        AddGameObject(objectMainMenu);

        return objectMainMenu.GetComponent<MainMenuView>();
    }

    private void StartGame()
    {
        _playerProfiler.CurrentState.Value = GameState.Start;
    }

    protected override void OnDispose()
    {
        _mainMenuView.ButtonStart.onClick.RemoveAllListeners();

        base.OnDispose();
    }
}
