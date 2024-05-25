using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TMP_Text xpTxt;
    public Image xpBar, lifeBar;
    private void Start()
    {
        instance = this;
        SetXp();
        SetLevel();
        SetLife();
    }

    private void Update()
    {

    }
    public void SetLevel()
    {
        xpTxt.text = $"lv:{PlayerStats.nivel}";
    }
    public void SetXp()
    {
        xpBar.fillAmount = (float)PlayerStats.xp / (float)PlayerStats.xpToNextLevel;
    }

    public void SetLife()
    {
        lifeBar.fillAmount = (float)PlayerStats.Instance.GetLife() / (float)PlayerStats.Instance.lifeMax;
    }
}
