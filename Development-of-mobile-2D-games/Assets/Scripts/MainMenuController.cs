using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/MainMenu" };
        private readonly ProfilerPlayer _playerProfiler;
        private readonly MainMenuView _mainMenuView;

        public MainMenuController(Transform placeForUI, ProfilerPlayer playerProfiler)
        {
            _playerProfiler = playerProfiler;
            _mainMenuView = LoadView(placeForUI);
            _mainMenuView.Init(StartGame);
            var tralController = new TrailController();
            AddController(tralController);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            var objectMainMenu = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath), placeForUI);
            AddGameObject(objectMainMenu);

            return objectMainMenu.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _playerProfiler.CurrentState.Value = GameState.Game;
        }

        protected override void OnDispose()
        {
            _playerProfiler.CurrentState.Value = GameState.Game;

            base.OnDispose();
        }
    }
}
