using System.Collections.Generic;
using UnityEngine;

public enum GunChose
{
    pistol, shotgun, uzi, sniper, sword, lance
}

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject[] gunPrefabs;
    [SerializeField] Transform player;
    [SerializeField] Transform gunsTransform;

    public static GunManager instance;
    List<Vector2> gunPositions = new List<Vector2>();

    [HideInInspector]public int spawnedGuns = 0;
    public int selectedGun;

    public GunChose gunChose;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gunsTransform = player.GetChild(4);
        print(gunsTransform);

        gunPositions.Add(new Vector2 (1f, 0f));
        gunPositions.Add(new Vector2 (-1f, 0f));

        gunPositions.Add(new Vector2(-0.25f, -0.7f));
        gunPositions.Add(new Vector2(0.75f, -0.7f));

        gunPositions.Add(new Vector2(-0.25f, 0.7f));
        gunPositions.Add(new Vector2(0.75f, 0.7f));

        instance = this;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddGun(0);
        }        
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddGun(1);
        }        
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddGun(2);
        }        
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddGun(3);
        }        
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddGun(4);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddGun(5);
        }
    }

    public void AddGun(int gun)
    {
        if (spawnedGuns >= gunPositions.Count)
        {
            return;
        }
        var pos = gunPositions[spawnedGuns];

        var newGun = Instantiate(gunPrefabs[gun], pos, Quaternion.identity);

        newGun.transform.SetParent(gunsTransform);

        if (newGun.GetComponent<Pistol>() != null)
        {
            newGun.GetComponent<Pistol>().SetOffset(pos);
        }
        else if (newGun.GetComponent<Shotgun>() != null)
        {
            newGun.GetComponent<Shotgun>().SetOffset(pos);
        }
        else if (newGun.GetComponent<Sword>() != null)
        {
            newGun.GetComponent<Sword>().SetOffset(pos);
        }
        spawnedGuns++;

        switch (gun)
        {
            case 0:
                gunChose = GunChose.sword;
                break;
                
            case 1:
                gunChose = GunChose.lance;
                break;

            case 2:
                gunChose = GunChose.pistol;
                break;

            case 3:
                gunChose = GunChose.shotgun;
                break;

            case 4:
                gunChose = GunChose.uzi;
                break;

            case 5:
                gunChose = GunChose.sniper;
                break;
        }
    }
    public void SelectGun(int gun)
    {
        selectedGun = gun;
    }
}
