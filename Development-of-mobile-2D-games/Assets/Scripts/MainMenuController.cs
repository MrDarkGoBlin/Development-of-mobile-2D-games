using Profile;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;

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
            Advertisement.AddListener(_playerProfiler.AdsListener);
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
            _playerProfiler.AnaliticsTools.SendMessage("Start", ("time" , Time.realtimeSinceStartup));
            _playerProfiler.AdsShower.ShowInterstitialVideo();
        }

        protected override void OnDispose()
        {
            _playerProfiler.CurrentState.Value = GameState.Game;

            Advertisement.RemoveListener(_playerProfiler.AdsListener);

            base.OnDispose();
        }
    }
}
