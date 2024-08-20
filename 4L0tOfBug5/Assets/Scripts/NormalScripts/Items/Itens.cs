using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]

    public GameObject[] allItens;
    public GameObject[] chosingItens;

    public GameObject Panel;
    public static Itens Instance;

    public void RandomItens()
    {
        for (int i = 0; i < chosingItens.Length-1; i++)
        {
            chosingItens[i] = allItens[Random.Range(0 , allItens.Length-1)];
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    
    public void restoreAllHp()
    {
        PlayerStats.Instance.life = PlayerStats.Instance.lifeMax;
    }
}
