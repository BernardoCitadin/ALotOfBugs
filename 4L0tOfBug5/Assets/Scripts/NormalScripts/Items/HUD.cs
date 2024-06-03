using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TMP_Text xpTxt, moneyTxt;
    public Image xpBar, lifeBar;
    private void Start()
    {
        instance = this;
        SetXp();
        SetLevel();
        SetLife();
        SetMoney();
    }

    public void SetLevel()
    {
        xpTxt.text = $"Lv: {PlayerStats.Instance.nivel}";
    }
    public void SetXp()
    {
        xpBar.fillAmount = (float)PlayerStats.xp / (float)PlayerStats.xpToNextLevel;
    }

    public void SetLife()
    {
        lifeBar.fillAmount = (float)PlayerStats.Instance.GetLife() / (float)PlayerStats.Instance.lifeMax;
    }

    public void SetMoney()
    {
        moneyTxt.text = $"Money: {PlayerStats.Instance.money}";
    }
}
