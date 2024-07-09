using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject[] gunPrefabs;
    [SerializeField] Transform player;

    public static GunManager Instance;
    List<Vector2> gunPositions = new List<Vector2>();

    [HideInInspector]public int spawnedGuns = 0;
    [HideInInspector]public int selectedGun;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunPositions.Add(new Vector2 (1f, 0f));
        gunPositions.Add(new Vector2 (-1f, 0f));

        gunPositions.Add(new Vector2(-0.25f, -0.7f));
        gunPositions.Add(new Vector2(0.75f, -0.7f));

        gunPositions.Add(new Vector2(-0.25f, 0.7f));
        gunPositions.Add(new Vector2(0.75f, 0.7f));

        Instance = this;

    }
    private void Start()
    {
        AddGun(selectedGun);
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
        var pos = gunPositions[spawnedGuns];

        var newGun = Instantiate(gunPrefabs[gun], pos, Quaternion.identity);

        newGun.transform.SetParent(player);

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
    }
    public void SelectGun(int gun)
    {
        selectedGun = gun;
    }
}
