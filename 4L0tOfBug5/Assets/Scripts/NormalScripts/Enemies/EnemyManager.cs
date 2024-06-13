using UnityEngine;

public enum TypeEnemy
{
    Terrestrial, Normal, Aerial
}
public enum ClassEnemy
{
    Strong, Normal, Fast
}
public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Config")]
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;

    float currentTimeBetweenSpawns;

    [Space(5)]
    [SerializeField]ClassEnemy classEnemy;

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

                break;
            case TypeEnemy.Normal:

                break;
            case TypeEnemy.Aerial:

                break;
        }

        switch (classEnemy)
        {
            case ClassEnemy.Strong:
                var e = Instantiate(enemyPrefab[0], RandomPostion(), Quaternion.identity);
                e.transform.SetParent(enemiesParent);
                break;
            case ClassEnemy.Normal:

                break;
            case ClassEnemy.Fast:

                break;
        }
    }

    Vector2 RandomPostion()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }

    void SpawnEnemy()
    {
        var ClassRandom = Random.Range(0, 2);
        var TypeRandom = Random.Range(0, 2);

        switch (ClassRandom)
        {
            case 0:
                classEnemy = ClassEnemy.Strong;
                break;
            case 1:
                classEnemy = ClassEnemy.Normal;
                break;
            case 2:
                classEnemy = ClassEnemy.Fast;
                break;
        }

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
