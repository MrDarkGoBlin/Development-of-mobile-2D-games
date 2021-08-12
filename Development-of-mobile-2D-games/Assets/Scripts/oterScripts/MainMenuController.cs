using Profile;
using System.Linq;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ui
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/MainMenu" };
        private readonly ProfilePlayer _playerProfiler;
        private readonly MainMenuView _mainMenuView;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _playerProfiler = profilePlayer;
            _mainMenuView = LoadView(placeForUI);
            _mainMenuView.Init(StartGame, DailyReward);
            var trarlController = new TrailController();
            AddController(trarlController);
            Advertisement.AddListener(_playerProfiler.AdsListener);


            //var shedController = ConfigureShedController(placeForUI, profilePlayer);
            //он не работает поэтому пока выключил
            //проблема в загрузке информации из scriptobleObject
        }

       

        private BaseController ConfigureShedController(
        Transform placeForUi,
        ProfilePlayer profilePlayer)
        {
            var upgradeItemsConfigCollection
                = ContentDataSourceLoader.LoadUpgradeItemConfig(new ResourcePath { PathResource = "DataSource/InfoItems/UpgradeItems" });
            var upgradeItemsRepository
                = new UpgradeHandlersRepository(upgradeItemsConfigCollection);
            var itemsRepository
                = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.ItemConfig).ToList());
            var inventoryModel
                = new InventoryModel();
            var inventoryViewPath
                = new ResourcePath { PathResource = $"Prefabs/{nameof(InventoryView)}" };
            var inventoryView
                = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObject(inventoryView.gameObject);
            var inventoryController
                = new InventoryController(inventoryModel, itemsRepository, inventoryView);
            AddController(inventoryController);

            var shedController
                = new ShedController(upgradeItemsRepository, inventoryController, profilePlayer.CurrentCar);
            AddController(shedController);

            return shedController;
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
            //_playerProfiler.AnaliticsTools.SendMessage("Start", ("time" , Time.realtimeSinceStartup));
            //_playerProfiler.AdsShower.ShowInterstitialVideo(); 
            // чтоб не мешало
        }

        protected override void OnDispose()
        {
            _playerProfiler.CurrentState.Value = GameState.Game;

            Advertisement.RemoveListener(_playerProfiler.AdsListener);

            base.OnDispose();
        }

        private void DailyReward()
        {
            _playerProfiler.CurrentState.Value = GameState.DailyReward;
        }
    }
}
