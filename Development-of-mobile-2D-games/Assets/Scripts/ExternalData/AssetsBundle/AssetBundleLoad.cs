using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public  class AssetBundleLoad
{
    private DataPrefabsBundle[] _dataPrefabsBundles;

    private Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();

    private AssetBundle _prefabsAssetBundle;

    public AssetBundleLoad(DataPrefabsBundle[] dataPrefabsBundles)
    {
        _dataPrefabsBundles = dataPrefabsBundles;
    }

    public Dictionary<string, GameObject> DownloadAndSetAssetBundle(string UrlAssetBundleSprites)
    {
        GetPrefabsAssetBundle(UrlAssetBundleSprites);

        if (_prefabsAssetBundle == null)
        {
            Debug.LogError("Not download asset bundle");
        }
        SetDownloadAsset();

        foreach (var item in _dataPrefabsBundles)
        {
            _prefabs.Add(item.NameAssetBundle ,item.Prefabs);
        }

        return _prefabs;
    }


    private void GetPrefabsAssetBundle(string UrlAssetBundleSprites)
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        while (!request.isDone)
        {
            Debug.Log("404 Not Found");
            break;
        }
            

        StateRequest(request, ref _prefabsAssetBundle);
        
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete download AssetBundle");
        }
        else
        {
            Debug.Log($"{request.error}");
        }
    }

    private void SetDownloadAsset()
    {
        foreach (var item in _dataPrefabsBundles)
        {
            item.Prefabs = _prefabsAssetBundle.LoadAsset<GameObject>(item.NameAssetBundle);
        }

    }
}