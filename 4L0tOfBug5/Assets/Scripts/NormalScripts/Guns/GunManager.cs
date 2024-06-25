using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject[] gunPrefabs;
    [SerializeField] Transform player;

    List<Vector2> gunPositions = new List<Vector2>();

    int spawnedGuns = 0;

    public int selectedGun;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunPositions.Add(new Vector2 (1f, 0f));
        gunPositions.Add(new Vector2 (-1f, 0f));

        gunPositions.Add(new Vector2(-0.25f, -0.7f));
        gunPositions.Add(new Vector2(0.75f, -0.7f));

        gunPositions.Add(new Vector2(-0.25f, 0.7f));
        gunPositions.Add(new Vector2(0.75f, 0.7f));

    }
    private void Start()
    {
        AddGun(selectedGun);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddGun(2);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddGun(4);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddGun(0);
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
