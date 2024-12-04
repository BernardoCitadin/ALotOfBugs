using UnityEngine;
using UnityEngine.Advertisements;

public class UnityRewarded : MonoBehaviour, IUnityAdsInitializationListener
{
    public string gameID = "";
    public string rewardedID = "Rewarded_Android";

    [SerializeField] bool _testMode = true;
    void Start()
    {
        Advertisement.Initialize(gameID, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    //ABOBORA
    public void ShowRew()
    {
        Advertisement.Show("Rewarded_Android");
        PlayerStats.Instance.AddMoney(5);
    }
    
    public void ShowInter()
    {
        Advertisement.Show("Interstitial_Android");
    }

}