//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
//using UnityEngine.UI;

//public  class LoadAssetsView 
//{
//    private const string UrlAssetBundlePrefabs = "https://drive.google.com/uc?export=download&id=1acCKY3YCmH7ySPAsHS734chC_wtH4H6A";

//    private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new List<AsyncOperationHandle<GameObject>>(); 

//    //private void Start()
//    //{
//    //    _button.onClick.AddListener(LoadAssets);
//    //    _buttonSpawnPrefab.onClick.AddListener(CreateAddresablePrefabe);
//    //}

    

//    //private void OnDestroy()
//    //{
//    //    _button.onClick.RemoveAllListeners();
//    //    _buttonSpawnPrefab.onClick.RemoveAllListeners();
//    //    foreach (var item in _addressablePrefabs)
//    //        Addressables.ReleaseInstance(item);

//    //    _addressablePrefabs.Clear();
//    //}

//    public Dictionary<string, GameObject> LoadAssets()
//    {
//       // return base.DownloadAndSetAssetBundle(UrlAssetBundlePrefabs);

//    }


//    //private void CreateAddresablePrefabe()
//    //{
//    //    var addressablePrefab = Addressables.InstantiateAsync(_assetReference, _rectTransform);
//    //    _addressablePrefabs.Add(addressablePrefab);

//    //}
//}
