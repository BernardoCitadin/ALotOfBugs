using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    float currentTimeBetweenSpawns;

    Transform enemiesParent;

    public static EnemyManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemy").transform;
    }
    private void Update()
    {
        currentTimeBetweenSpawns -= Time.deltaTime;

        if(currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }
    }

    Vector2 RandomPostion()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }

    void SpawnEnemy()
    {
        var e = Instantiate(enemyPrefab, RandomPostion(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
        {
            Destroy(e.gameObject);
        }
    }
}
