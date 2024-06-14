using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Events;

public class WeaponChoice : MonoBehaviour
{
    public static WeaponChoice instance;
    #region Variables
    public TMP_Text[] weaponName;
    GameObject[] choiseWeapons = new GameObject[4];

    public UnityEvent OnLuck;
    #endregion

    private void Awake()
    {
        instance = this;
    }
    public void ChooseWeapon()
    {
        List<GameObject> weapons = PlayerStats.Instance.weapons.ToList();
        for (int i = 0; i < weaponName.Length; i++)
        {
            int randoNumber = Random.Range(0, weapons.Count);
            choiseWeapons[i] = weapons[randoNumber];
            weapons.RemoveAt(randoNumber);
            weaponName[i].text = choiseWeapons[i].name;
            if (i == 2)
            {
                if (PlayerStats.luck == 0)
                    return;

                if (Random.Range(0, 100) < 1 - 1 / PlayerStats.luck)
                {
                    OnLuck.Invoke();
                }
                else
                    break;
            }
        }
    }

    public void WeaponChoosed(int id)
    {
        if (PlayerStats.Instance.weapons.Count == 0)
        {
            return;
        }
        for (int i = 0;i < PlayerStats.Instance.weapons.Count;i++)
        {
            if (PlayerStats.Instance.weapons[i].name.Equals(choiseWeapons[id].name))
            {
                print("Foi coletado");
            }
            else
                if (i == PlayerStats.Instance.weapons.Count-1)
            {
                PlayerStats.Instance.weapons.Add(choiseWeapons[id]);
                break;
            }
        }
    }
}
