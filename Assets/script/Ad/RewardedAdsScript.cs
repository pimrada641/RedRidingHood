using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardedAdsScript : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    //public Transform horiVertiInput;
    public Button myButton;
    //public GameObject GameoverScreen;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    //bool testMode = true;
    string _adUnitId = null;
    Coroutine runningCoroutine;
    bool stopCoroutine = false;

    //GameObject player;
    private int currentLevel;

    void Awake()
    {
        
        // Get the Ad Unit ID for the current platform:
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
        //Disable the button until the ad is ready to show:
        myButton.interactable = false;
    }

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        //player = GameObject.FindWithTag("Player");
        runningCoroutine = StartCoroutine(AdsCoroutine());
    }

    IEnumerator AdsCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Advertisement.isInitialized = " + Advertisement.isInitialized);
        if (Advertisement.isInitialized)
        {
            stopCoroutine = true;
        }
    }

    void Update()
    {
        if (stopCoroutine == true)
        {
            StopCoroutine(runningCoroutine);
            stopCoroutine = false;
            LoadAd();
        }
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            myButton.onClick.AddListener(ShowAd);

            // Enable the button for users to click:
            myButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        Time.timeScale = 0f;
        // Disable the button:
        myButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            
            //player.transform.position = new Vector3(horiVertiInput.position.x,horiVertiInput.position.y);
            Time.timeScale = 1f;

            Restart();

            // Load another ad:
            //Advertisement.Load(_adUnitId, this);
        }
    }

    public void Restart(){
        SceneManager.LoadScene(currentLevel);
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        myButton.onClick.RemoveAllListeners();
    }
}