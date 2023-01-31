using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        if (Advertisement.isInitialized)
        {
            LoadInterstitialAd();

        }
        else
        {
            InitializeAds();
        }
    }




    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        
        Advertisement.Initialize(_gameId, _testMode, this);
    }



    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadInterstitialAd();

    }


    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }


    // Indestrial Ads
    public void LoadInterstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }



    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error Showing Ad Unit: {error.ToString()} - {message}");
    }







    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowFailure");
        Time.timeScale = 0;
        AudioManager.instance.StopSound("GameMusic");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowFailure");
        Time.timeScale = 1;
        AudioManager.instance.PlaySound("GameMusic");
    }
}
