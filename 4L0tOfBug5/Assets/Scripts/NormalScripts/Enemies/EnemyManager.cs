using UnityEngine;

public enum TypeEnemy
{
    Terrestrial, Normal, Aerial
}
public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Config")]
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;

    float currentTimeBetweenSpawns;

    [Space(5)]
    [SerializeField]TypeEnemy typeEnemy;

    Transform enemiesParent;

    public static EnemyManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemys").transform;
    }
    private void Update()
    {
        if (!WaveManager.Instance.WaveRunning()) return;

        currentTimeBetweenSpawns -= Time.deltaTime;

        if(currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }

        switch (typeEnemy)
        {
            case TypeEnemy.Terrestrial:
                var TerrestrialFenotype = Random.Range(0, 2);
                switch (TerrestrialFenotype)
                {
                    case 0:
                        var Fast = Instantiate(enemyPrefab[0], RandomPostion(), Quaternion.identity);
                        Fast.transform.SetParent(enemiesParent);
                        break;
                    case 1:
                        var Normal = Instantiate(enemyPrefab[1], RandomPostion(), Quaternion.identity);
                        Normal.transform.SetParent(enemiesParent);
                        break;
                    case 2:
                        var Strong = Instantiate(enemyPrefab[2], RandomPostion(), Quaternion.identity);
                        Strong.transform.SetParent(enemiesParent);
                        break;
                }
                break;
            case TypeEnemy.Normal:
                var NormalFenotype = Random.Range(0, 2);
                switch (NormalFenotype)
                {
                    case 0:
                        var Fast = Instantiate(enemyPrefab[3], RandomPostion(), Quaternion.identity);
                        Fast.transform.SetParent(enemiesParent);
                        break;
                    case 1:
                        var Normal = Instantiate(enemyPrefab[4], RandomPostion(), Quaternion.identity);
                        Normal.transform.SetParent(enemiesParent);
                        break;
                    case 2:
                        var Strong = Instantiate(enemyPrefab[5], RandomPostion(), Quaternion.identity);
                        Strong.transform.SetParent(enemiesParent);
                        break;
                }
                break;
            case TypeEnemy.Aerial:
                var AerialFenotype = Random.Range(0, 2);
                switch (AerialFenotype)
                {
                    case 0:
                        var Fast = Instantiate(enemyPrefab[6], RandomPostion(), Quaternion.identity);
                        Fast.transform.SetParent(enemiesParent);
                        break;
                    case 1:
                        var Normal = Instantiate(enemyPrefab[7], RandomPostion(), Quaternion.identity);
                        Normal.transform.SetParent(enemiesParent);
                        break;
                    case 2:
                        var Strong = Instantiate(enemyPrefab[8], RandomPostion(), Quaternion.identity);
                        Strong.transform.SetParent(enemiesParent);
                        break;
                }
                break;
        }
    }

    Vector2 RandomPostion()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }

    void SpawnEnemy()
    {
        var TypeRandom = Random.Range(0, 2);

        switch (TypeRandom)
        {
            case 0:
                typeEnemy = TypeEnemy.Terrestrial;
                break;
            case 1:
                typeEnemy = TypeEnemy.Normal;
                break;
            case 2:
                typeEnemy = TypeEnemy.Aerial;
                break;
        }
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
        {
            Destroy(e.gameObject);
        }
    }
}
