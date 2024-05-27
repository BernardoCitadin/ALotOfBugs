using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject[] gunPrefabs;
    [SerializeField] Transform player;

    List<Vector2> gunPositions = new List<Vector2>();

    int spawnedGuns = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gunPositions.Add(new Vector2 (1f, 0f));
        gunPositions.Add(new Vector2 (-1f, 0f));

        gunPositions.Add(new Vector2(-0.25f, -0.7f));
        gunPositions.Add(new Vector2(0.75f, -0.7f));

        gunPositions.Add(new Vector2(-0.25f, 0.7f));
        gunPositions.Add(new Vector2(0.75f, 0.7f));

        AddGun(0);
        AddGun(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AddGun(0);
        }
    }

    void AddGun(int gun)
    {
        var pos = gunPositions[spawnedGuns];

        var newGun = Instantiate(gunPrefabs[gun], pos, Quaternion.identity); 
        
        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;
    }
}
