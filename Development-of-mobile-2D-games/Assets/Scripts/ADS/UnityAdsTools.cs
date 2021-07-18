using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : IAdsShower, IUnityAdsListener
{
    private const string _gameAndroidID = "4222517";
    private const string _rewardedPlacementID = "Rewarded_Android";
    private const string _interstitialPlacementID = "Interstitial_Android";
    private const string _bannerPlacementID = "Banner_Android";

    public UnityAdsTools()
    {
        Advertisement.Initialize("4222517", true);
    }
    #region IAdsShower
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacementID);
    }

    public void ShowRewardedVidio()
    {
        Advertisement.Show(_rewardedPlacementID);
    }
    public void ShowInterstitialVideo()
    {
        Advertisement.Show(_interstitialPlacementID);
    }
    #endregion

    #region IUnityAdsListener

    public void OnUnityAdsDidError(string message)
    {
    }   

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("end");
        }
    }
    #endregion
}
