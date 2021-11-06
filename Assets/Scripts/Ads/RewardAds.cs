using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class RewardAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;
    [SerializeField] private Button adsButton;
    [SerializeField] private AudioMixerSnapshot snapMute;
    [SerializeField] private AudioMixerSnapshot snapNormal;
    [SerializeField] private GameObject adsView;
    [SerializeField] private Toggle mute;
    private Animator bulbAnim;
    private string gameId = "4437313";
    private string rewardedVideo = "Rewarded_Android";
    private void Start()
    {
        bulbAnim = adsView.GetComponentInChildren<Animator>();
        adsButton = GetComponent<Button>();
        adsButton.interactable = Advertisement.IsReady(rewardedVideo);
        if (adsButton)
        {
            adsButton.onClick.AddListener(ShowRewardedVideo);
        }
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }
    private void Update()
    {
        adsButton.interactable = Advertisement.IsReady(rewardedVideo);
    }
    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideo);
        StartCoroutine(DelayAds());
    }
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardedVideo)
        {
            adsButton.interactable = true;
            bulbAnim.Play("BulbMove", 1);
        }
    }
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("AdsError");
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        snapMute.TransitionTo(0);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (mute.isOn)
            {
                snapNormal.TransitionTo(0);
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            if (mute.isOn)
            {
                snapNormal.TransitionTo(0);
            }
        }
        else if (showResult == ShowResult.Failed)
        {
            if (mute.isOn)
            {
                snapNormal.TransitionTo(0);
            }
        }
    }
    private IEnumerator DelayAds()
    {
        adsView.SetActive(false);
        yield return new WaitForSeconds(300);
        adsView.SetActive(true);
    }
}
