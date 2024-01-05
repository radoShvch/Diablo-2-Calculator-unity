using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    private static readonly string storeID = "4150339";

#elif UNITY_IOS
    private static readonly string storeID = "4150338";
#endif
    private static readonly string videoID = "Banner_Android";
    //private static readonly string rewardedvideoID = "Banner_Android";
    private static readonly string bannerID = "Banner_Android";

#if UNITY_EDITOR
    private static bool testMode = true;
#else
    private static bool testMode = false;
#endif

    public static AdManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(storeID, testMode);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static void ShowStandardAd()
    {
        if (Advertisement.IsReady(videoID))
            Advertisement.Show(videoID);
    }
    public static void ShowBanner()
    {
        instance.StartCoroutine(ShowBannerWhenReady());
    }
    public static void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    private static IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerID))
            yield return new WaitForSeconds(0.5f);

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerID);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

    }

    public void OnUnityAdsDidError(string message) { }
    public void OnUnityAdsDidStart(string placementId) { }
    public void OnUnityAdsReady(string placementId) { }
}
