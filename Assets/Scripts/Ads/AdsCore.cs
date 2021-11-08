using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsCore : MonoBehaviour
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private GameObject _noAds;
    private static GameObject _noAdsStat;
    private string gameId = "4437313";
    private string video = "Interstitial_Android";
    private string rewardedVideo = "Rewarded_Android";
    private string banner = "Banner_Android";
    private void Start()
    {
        _noAdsStat = _noAds;
        Advertisement.Initialize(gameId, testMode);
        #region Banner
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        #endregion
    }
    private IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(banner);
    }
    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            _noAdsStat.SetActive(true);
        }
    }
}
