using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadAssetsView : AssetBundleViewBase
{
    [SerializeField]
    private AssetReference _assetReference;
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Button _buttonSpawnPrefab;

    private float timer = 0.0f;

    private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new List<AsyncOperationHandle<GameObject>>(); 

    private void Start()
    {
        _button.onClick.AddListener(LoadAssets);
        _buttonSpawnPrefab.onClick.AddListener(CreateAddresablePrefabe);
    }

    

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
        _buttonSpawnPrefab.onClick.RemoveAllListeners();
        foreach (var item in _addressablePrefabs)
            Addressables.ReleaseInstance(item);

        _addressablePrefabs.Clear();
    }

    private void LoadAssets()
    {
        Debug.Log($"Start!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        _button.interactable = false;
        StartCoroutine(DownloadAndSetAssetBundle());
    }
    private void CreateAddresablePrefabe()
    {
        var addressablePrefab = Addressables.InstantiateAsync(_assetReference, _rectTransform);
        _addressablePrefabs.Add(addressablePrefab);

    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }
}
