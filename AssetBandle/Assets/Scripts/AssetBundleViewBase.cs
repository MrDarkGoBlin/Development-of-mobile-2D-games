using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleViewBase : MonoBehaviour
{
    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1acCKY3YCmH7ySPAsHS734chC_wtH4H6A";
    private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1AEC0TGTttn4aTUW3e_YekMSPTHyrt82V";

    [SerializeField]
    private DataAudioBundle[] _dataAudioBundles;

    [SerializeField]
    private DataSpriteBundle[] _dataSpriteBundles;

    private AssetBundle _spritesAssetBundle;
    private AssetBundle _audioAssetBundle;

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();
        yield return GetAudioAssetBundle();

        if (_spritesAssetBundle == null || _audioAssetBundle == null)
        {
            Debug.LogError("Not download asset bundle");
            yield break;
        }
        SetDownloadAsset();
        Debug.Log("End!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        yield return null;
    }

   

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _audioAssetBundle);
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request,ref _spritesAssetBundle);
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
        foreach (var item in _dataSpriteBundles)
            item.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(item.NameAssetBundle);

        foreach (var item in _dataAudioBundles)
        {
            item.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(item.NameAssetBundle);
            item.AudioSource.Play();
        }
    }
}