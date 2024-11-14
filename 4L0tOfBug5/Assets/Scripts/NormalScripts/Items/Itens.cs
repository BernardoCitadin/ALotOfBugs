using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
            GameObject[] guns = GameObject.FindGameObjectsWithTag("Guns");
            foreach (var gun in guns)
            {
                var gunCode = gun.GetComponent<Gun>();
                switch (gunCode.type)
                {
                    case GunType.Pistol:
                        gunCode.damage += 5;
                        break;
                    case GunType.Shotgun:
                        gunCode.damage += 7;
                        break;
                    case GunType.MicroUzi:
                        gunCode.damage += 0.2f;
                        break;
                    case GunType.Sniper:
                        gunCode.damage += 15;
                        break;
                    case GunType.Sword:
                        Sword swordCode = gunCode.gameObject.GetComponent<Sword>();
                        swordCode.gameObject.GetComponentInChildren<Bullet>().damage += 10;
                        gunCode.damage += 10;
                        break;
                    case GunType.Lance:
                        Sword lanceCode = gunCode.gameObject.GetComponent<Sword>();
                        lanceCode.gameObject.GetComponentInChildren<Bullet>().damage += 10;
                        gunCode.damage += 10;
                        break;
                }
            }
        }
    }
    public void IncreaseAtackSpeed(int cost)
    {
        if (PlayerStats.Instance.money >= cost)
        {
            PlayerStats.Instance.Cost(cost);
            GameObject[] guns = GameObject.FindGameObjectsWithTag("Guns");
            foreach (var gun in guns)
            {
                var gunCode = gun.GetComponent<Gun>();
                switch (gunCode.type)
                {
                    case GunType.Pistol:
                        gunCode.fireRate -= 0.05f;
                        break;
                    case GunType.Shotgun:
                        gunCode.fireRate -= 0.1f;
                        break;
                    case GunType.MicroUzi:
                        gunCode.fireRate -= 0.05f;
                        break;
                    case GunType.Sniper:
                        gunCode.fireRate -= 0.3f;
                        break;
                    case GunType.Sword:
                        gunCode.fireRate -= 0.25f;
                        break;
                    case GunType.Lance:
                        gunCode.fireRate -= 0.15f;
                        break;
                }
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
