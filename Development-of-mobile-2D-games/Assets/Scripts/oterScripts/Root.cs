using Profile;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
    private UnityAdsTools _unityAdsTools;
    [SerializeField]
    private DailyRewardView _dailyRewardView;
    [SerializeField]
    private StartFightView _startFightView;
    [SerializeField]
    private FightWindowView _fightWindowView;
    [SerializeField]
    private CurrencyView _currencyView;
    [SerializeField]
    private  string UrlAssetBundlePrefabs = "https://drive.google.com/uc?export=download&id=1RRXNf4kGWnc6mtaNAO5lgLx9ua_i9KIs";

    [SerializeField]
    private DataPrefabsBundle[] _dataPrefabsBundles;
    [SerializeField]
    private List<ItemConfig> _itemsConfig;
    [SerializeField]
    private List<UpgradeItemConfig> _upgradeItemsConfig;
    [SerializeField]
    private List<AbilityItemConfig> _abilityItemsConfig;

    private Dictionary<string, GameObject> _prefabs;
    private MainController _mainController;
    private AssetBundleLoad _assetBundleLoad;

    private void Awake()
    {

        _assetBundleLoad = new AssetBundleLoad(_dataPrefabsBundles);
        _prefabs = _assetBundleLoad.DownloadAndSetAssetBundle(UrlAssetBundlePrefabs);
        _unityAdsTools = new UnityAdsTools();
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _dailyRewardView, _startFightView, _fightWindowView, _currencyView, _prefabs);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
