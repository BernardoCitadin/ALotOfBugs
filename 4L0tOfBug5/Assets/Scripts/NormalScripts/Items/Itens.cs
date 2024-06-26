using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int hpToAdd;
    [SerializeField] int stghToAdd;
    [SerializeField] float atckSpdToAdd;
    [SerializeField] float spdToAdd;
    [SerializeField] int regenValue;

    public GameObject Panel;

    float AtckSpdRepairDmg = 0.5f;
    public static Itens Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ItemActivate()
    {
        hpToAdd = Random.Range(5, 15);
        spdToAdd = Random.Range(0.3f, 0.6f);
        stghToAdd = Random.Range(1, 3);
        atckSpdToAdd = Random.Range(0.05f, 0.10f);
    }

    public void hpItem()
    {
        if (PlayerStats.Instance.money >= 2)
        {
            PlayerStats.Instance.Cost(2);
        }
        else
            return;
        PlayerStats.Instance.lifeMax += hpToAdd;
        AtckSpdRepairDmg += atckSpdToAdd;
    }

    public void atckSpdItem()
    {
        if (PlayerStats.Instance.money >= 3)
        {
            PlayerStats.Instance.Cost(3);
        }
        else
            return;
        if (Bullet.Instance.damage > stghToAdd)
        {
            Bullet.Instance.damage -= stghToAdd;
        }
        else Bullet.Instance.damage = 1;

        AtckSpdRepairDmg -= atckSpdToAdd;
    }
    public void stghItem()
    {
        if (PlayerStats.Instance.money >= 4)
        {
            PlayerStats.Instance.Cost(4);
        }
        else
            return;
        //Bullet.Instance.damage += stghToAdd;
        Bullet.Instance.damage += stghToAdd;
        PlayerMovement.Instance.speed -= spdToAdd;
    }

    public void spdItem()
    {
        if (PlayerStats.Instance.money >= 1)
        {
            PlayerStats.Instance.Cost(1);
        }
        else
            return;
        PlayerMovement.Instance.speed += spdToAdd;
        PlayerStats.Instance.life -= hpToAdd;
        PlayerStats.Instance.lifeMax -= hpToAdd;
    }

    public void regenItem()
    {
        if (PlayerStats.Instance.money >= 1)
        {
            PlayerStats.Instance.Cost(1);
        }
        else
            return;
        PlayerStats.Instance.life += regenValue;
    }
    
    public void restoreAllHp()
    {
        PlayerStats.Instance.life = PlayerStats.Instance.lifeMax;
    }
}
