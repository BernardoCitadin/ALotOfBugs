using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int hpToAdd;
    [SerializeField] float stghToAdd;
    [SerializeField] float atckSpdToAdd;
    [SerializeField] float spdToAdd;
    [SerializeField] int regenValue;

    public GameObject Panel;
    public static Itens Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ItemRoll()
    {
        hpToAdd = Random.Range(5, 15);
        spdToAdd = Random.Range(0.3f, 0.6f);
        stghToAdd = Random.Range(0.5f, 1.5f);
        atckSpdToAdd = Random.Range(0.05f, 0.10f);
    }

    public void hpItem()
    {
        if (PlayerStats.Instance.money >= 2)
        {
            PlayerStats.Instance.Cost(2);
            PlayerStats.Instance.lifeMax += hpToAdd;
            PlayerStats.Instance.life = PlayerStats.Instance.lifeMax;
        }
        else
            return;
    }

    public void atckSpdItem()
    {
        if (PlayerStats.Instance.money >= 3)
        {
            PlayerStats.Instance.Cost(3);
            if(Gun.Instance.fireRate > 0.1)
            Gun.Instance.fireRate -= atckSpdToAdd;
            else
                Gun.Instance.fireRate = 0.1f;   
        }
        else
            return;
    }
    public void stghItem()
    {
        if (PlayerStats.Instance.money >= 4)
        {
            PlayerStats.Instance.Cost(4);
            Bullet.Instance.damage += stghToAdd;
        }
        else
            return;
    }

    public void spdItem()
    {
        if (PlayerStats.Instance.money >= 1)
        {
            PlayerStats.Instance.Cost(1);
            PlayerMovement.Instance.speed += spdToAdd;
        }
        else
            return;
    }

    public void regenItem()
    {
        if (PlayerStats.Instance.money >= 1)
        {
            PlayerStats.Instance.Cost(1);
            PlayerStats.Instance.life += regenValue;
        }
        else
            return;
    }
    
    public void restoreAllHp()
    {
        PlayerStats.Instance.life = PlayerStats.Instance.lifeMax;
    }
}
