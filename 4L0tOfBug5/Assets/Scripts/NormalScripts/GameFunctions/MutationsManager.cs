using UnityEngine;
using UnityEngine.Events;

public class MutationsManager : MonoBehaviour
{
    public static MutationsManager Instance;
    public GameObject[] Mutations;
    public UnityEvent RefreshAll;
    public GameObject mutations, shop;
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
