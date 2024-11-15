using UnityEngine;
using UnityEngine.Events;

public class MutationsManager : MonoBehaviour
{
    public static MutationsManager Instance;
    public GameObject[] Mutations;
    public UnityEvent RefreshAll;
    public GameObject mutations, shop;

    public bool mutation1;
    public bool mutation2;
    public bool mutation3;
    public bool mutation4;

    void Awake()
    {
        Instance = this;
    }
    public void Refresh()
    {
        if (PlayerStats.Instance.passedLevels >= 1)
        {
            PlayerStats.Instance.passedLevels--;
            RefreshAll.Invoke();
        }
        else
        {
            mutations.gameObject.SetActive(false);
            shop.gameObject.SetActive(true);
        }
    }
}
