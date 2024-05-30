using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public static int nivel = 1;
    public static int xp = 0, xpToNextLevel = 5;
    public GameObject panelRestart;

    public int xpIncrease = 10, lifeMax = 100;
    public static int luck;
    public int life;

    public UnityEvent OnPause, OnUnpause, OnLevelUp;


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

    private void Awake()
    {
        Instance = this;
        life = lifeMax;
    }
    public static void GainXp(int xpGain)
    {
        xp += xpGain;
        HUD.instance.SetXp();
        if (xp >= xpToNextLevel)
        {
            PlayerStats.nivel++;
            xp = 0;
            xpToNextLevel += PlayerStats.Instance.xpIncrease;
            HUD.instance.SetXp();
            HUD.instance.SetLevel();
            PlayerStats.Instance.OnLevelUp.Invoke();
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
            }
        }
    }

    public int GetLife()
    {
        return life;
    }
}
