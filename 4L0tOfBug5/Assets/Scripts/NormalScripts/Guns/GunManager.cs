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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunPositions.Add(new Vector2 (1f, 0f));
        gunPositions.Add(new Vector2 (-1f, 0f));

        gunPositions.Add(new Vector2(-0.25f, -0.7f));
        gunPositions.Add(new Vector2(0.75f, -0.7f));

        gunPositions.Add(new Vector2(-0.25f, 0.7f));
        gunPositions.Add(new Vector2(0.75f, 0.7f));

        AddGun(selectedGun);
        //AddGun(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddGun(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddGun(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddGun(2);
        }
    }

    void AddGun(int gun)
    {
        var pos = gunPositions[spawnedGuns];

        var newGun = Instantiate(gunPrefabs[gun], pos, Quaternion.identity);
        newGun.transform.SetParent(player);

        if (newGun.GetComponent<Gun>() != null)
        {
            newGun.GetComponent<Gun>().SetOffset(pos);
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
}
