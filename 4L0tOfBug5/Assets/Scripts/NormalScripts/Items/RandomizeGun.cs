using UnityEngine;
using TMPro;

public class RandomizeGun : MonoBehaviour
{
    public static RandomizeGun instance; 

    int randomGun;
    int cost;

    public TMP_Text text;

    private void OnBecameVisible()
    {
        Randomize();
        CorrectGun();
    }

    private void Awake()
    {
        instance = this;
    }

    public void CorrectGun()
    {
        switch (randomGun)
        {
            case 0:
                text.text = "Sword" + "\n" + "2 R$";
                cost = 2;
                break; 
            case 1:
                text.text = "Lance" + "\n" + "3 R$";
                cost = 3;
                break;
            case 2:
                text.text = "Pistol" + "\n" + "3 R$";
                cost = 3;
                break;
            case 3:
                text.text = "ShotGun" + "\n" + "5 R$";
                cost = 5;
                break;
            case 4:
                text.text = "Uzi" + "\n" + "6 R$";
                cost = 6;
                break;
            case 5:
                text.text = "Sniper" + "\n" + "4 R$";
                cost = 4;
                break;
        }
    }

    public void AddGun()
    {
        if (GunManager.instance.spawnedGuns > 6)
        {
            //Limite de armas
            return;
        }
        if (cost <= PlayerStats.Instance.money)
        {
            Cost();
            GunManager.instance.AddGun(randomGun);
            Randomize();
            CorrectGun();
        }
        

    }

    public void Randomize()
    {
        randomGun = Random.Range(0, 6);
    }

    public void Cost()
    {
        PlayerStats.Instance.Cost(cost);
    }
}
