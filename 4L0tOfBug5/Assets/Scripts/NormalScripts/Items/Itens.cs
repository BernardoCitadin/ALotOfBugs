using UnityEngine;

public class Itens : MonoBehaviour
{
    [Header("Values")]
    public float speedIncreases;
    public float regenIncreases;
    public float lifeIncreases;

    public GameObject Panel;
    public static Itens Instance;

    private void Awake()
    {
        Instance = this;
    }    
    
    public void IncreaseStrength(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            
            switch (GunManager.instance.gunChose)
            {
                case GunChose.sword:
                    var sword = FindObjectOfType<Sword>();
                    var damageSword = sword.gameObject.GetComponentInChildren<Bullet>();
                    damageSword.damage += 10;
                    break;
                case GunChose.lance:
                    var lance = FindObjectOfType<Sword>();
                    var damageLance = lance.gameObject.GetComponentInChildren<Bullet>();
                    damageLance.damage += 5;
                    break;
                case GunChose.pistol:
                    var pistol = FindObjectOfType<Pistol>();
                    pistol.projectile.GetComponent<Bullet>().damage += 5;
                    break;
                case GunChose.shotgun:
                    var shotgun = FindObjectOfType<Shotgun>();
                    shotgun.projectile.GetComponent<Bullet>().damage += 7;
                    break;
                case GunChose.uzi:
                    var uzi = FindObjectOfType<Pistol>();
                    uzi.projectile.GetComponent<Bullet>().damage += 0.2f;
                    break;
                case GunChose.sniper:
                    var sniper = FindObjectOfType<Pistol>();
                    sniper.projectile.GetComponent<Bullet>().damage += 15;
                    break;
            }
            
        }
    }
    public void IncreaseAtackSpeed(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            switch (GunManager.instance.gunChose)
            {
                case GunChose.sword:
                    var sword = FindObjectOfType<Sword>();
                    sword.fireRate -= 0.15f;
                    break;
                case GunChose.lance:
                    var lance = FindObjectOfType<Sword>();
                    lance.fireRate -= 0.15f;
                    break;
                case GunChose.pistol:
                    var pistol = FindObjectOfType<Pistol>();
                    pistol.fireRate -= 0.05f;
                    break;
                case GunChose.shotgun:
                    var shotgun = FindObjectOfType<Shotgun>();
                    shotgun.fireRate -= 0.1f;
                    break;
                case GunChose.uzi:
                    var uzi = FindObjectOfType<Pistol>();
                    uzi.fireRate -= 0.02f;
                    break;
                case GunChose.sniper:
                    var sniper = FindObjectOfType<Pistol>();
                    sniper.fireRate -= 0.3f;
                    break;
            }
        }
    }
    public void IncreaseSpeed(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            PlayerMovement.Instance.speed += speedIncreases;
        }
    }
    public void IncreaseRegen(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            PlayerStats.Instance.regen += regenIncreases;
        }
    }
    public void IncreaseLife(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            PlayerStats.Instance.lifeMax += lifeIncreases;
        }
    }

    public void restoreAllHp()
    {
        PlayerStats.Instance.life = PlayerStats.Instance.lifeMax;
    }
}
