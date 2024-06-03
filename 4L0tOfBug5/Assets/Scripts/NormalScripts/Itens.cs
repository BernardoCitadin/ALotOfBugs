using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] int hpToAdd;
    [SerializeField] int stghToAdd;
    [SerializeField] float atckSpdToAdd;
    [SerializeField] float spdToAdd;

    public GameObject Panel;

    float AtckSpdRepairDmg = 0.5f;
    public static Itens Instance;

    private void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        Gun.Instance.fireRate = AtckSpdRepairDmg;
    }

    public void ItemActivate()
    {
        hpToAdd = Random.Range(5, 15);
        spdToAdd = Random.Range(0.3f, 0.6f);
        stghToAdd = Random.Range(1, 3);
        atckSpdToAdd = Random.Range(0.05f, 0.10f);
        print(PlayerStats.Instance.lifeMax);
        print(Gun.Instance.fireRate);
        print(Bullet.Instance.damage);
        print(PlayerMovement.Instance.speed);
    }

    public void hpItem()
    {
        PlayerStats.Instance.lifeMax += hpToAdd;
        print(PlayerStats.Instance.lifeMax);
        AtckSpdRepairDmg += atckSpdToAdd;
        print(Gun.Instance.fireRate);
        Panel.SetActive(false);
        if (PlayerStats.Instance.money >= 2)
        {
            PlayerStats.Instance.Cost(2);
        }
    }

    public void atckSpdItem()
    {
        if (Bullet.Instance.damage > stghToAdd)
        {
            Bullet.Instance.damage -= stghToAdd;
        }
        else Bullet.Instance.damage = 1;

            print(Bullet.Instance.damage);
        AtckSpdRepairDmg -= atckSpdToAdd;
        print(Gun.Instance.fireRate);
        Panel.SetActive(false);
        if (PlayerStats.Instance.money >= 3)
        {
            PlayerStats.Instance.Cost(3);
        }
    }
    public void stghItem()
    {
        //Bullet.Instance.damage += stghToAdd;
        Bullet.Instance.damage += stghToAdd;
        print(Bullet.Instance.damage);
        PlayerMovement.Instance.speed -= spdToAdd;
        print(PlayerMovement.Instance.speed);
        Panel.SetActive(false);
        if (PlayerStats.Instance.money >= 4)
        {
            PlayerStats.Instance.Cost(4);
        }
    }

    public void spdItem()
    {
        PlayerMovement.Instance.speed += spdToAdd;
        print(PlayerMovement.Instance.speed);
        PlayerStats.Instance.life -= hpToAdd;
        PlayerStats.Instance.lifeMax -= hpToAdd;
        print(PlayerStats.Instance.lifeMax);
        Panel.SetActive(false);
        if (PlayerStats.Instance.money >= 1)
        {
            PlayerStats.Instance.Cost(1);
        }
    }
}
