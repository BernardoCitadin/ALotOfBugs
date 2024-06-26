using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int nivel = 1;
    public int passedLevels = 0;
    public static int xp = 0, xpToNextLevel = 5;
    public GameObject panelRestart;
    public int money = 0;

    public int xpIncrease = 10, lifeMax = 100;
    public static int luck;
    public int life;

    public UnityEvent OnPause, OnUnpause, OnLevelUp;

    public List<GameObject> weapons;


    private void Awake()
    {
        Instance = this;
        life = lifeMax;
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                OnUnpause.Invoke();
            }
            else
            {
                Time.timeScale = 0;
                OnPause.Invoke();
            }
        }
    }

    public static void GainXp(int xpGain)
    {
        xp += xpGain;
        HUD.instance.SetXp();
        if (xp >= xpToNextLevel)
        {
            PlayerStats.Instance.nivel++;
            PlayerStats.Instance.passedLevels++;
            xp = 0;
            xpToNextLevel += PlayerStats.Instance.xpIncrease;
            HUD.instance.SetXp();
            HUD.instance.SetLevel();
        }
    }

    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void LevelAmount(int levelAmount)
    {
        levelAmount++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Enemy>().damage;
            HUD.instance.SetLife();
            if (life <= 0)
            {
                gameObject.SetActive(false);
                panelRestart.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void AddMoney(int Value)
    {
        money += Value;
        HUD.instance.SetMoney();
    }

    public void Cost(int cost)
    {       
        money -= cost;
        HUD.instance.SetMoney();

    }
    public int GetLife()
    {
        return life;
    }

    public void ResetPos()
    {
        gameObject.transform.position = Vector3.zero;
    }
}
