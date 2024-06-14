using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public static PlayerWeapons Instance;
    //public List<GameObject> Weapons = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }


}
