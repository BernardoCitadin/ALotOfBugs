using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Transform player;

    [Header("Fire Settings")]
    [SerializeField] public float fireDistance;
    [SerializeField] public float fireRate;

    public Vector2 offset;
    SpriteRenderer spg;

    [Header("Shot Settings")]
    public float lastShotTime;
    [HideInInspector]public Transform closeEnemy;

    public static Gun Instance;

    [HideInInspector]public float angle;

    [Header("Set Melee Weapon")]
    [SerializeField] bool isMelee;
    private void Awake()
    {
        Instance = this;
    }

    protected virtual void FindCloseEnemy()
    {
        closeEnemy = null;
        float closeDistance = Mathf.Infinity;

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closeDistance && distance < fireDistance)
            {
                closeDistance = distance;
                closeEnemy = enemy.transform;
            }
        }
    }

    protected virtual void Aim()
    {
        if(closeEnemy != null)
        {
            Vector3 direction = closeEnemy.position - transform.position;
            direction.Normalize();

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0,0,angle);

            transform.position = (Vector2)player.position + offset;
        }
        else if(closeEnemy == null && isMelee)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected virtual void Shooting()
    {
        lastShotTime += Time.deltaTime;
        if (closeEnemy == null)
        {
            return;
        }
        if (lastShotTime >= fireRate)
        {
            Shoot();
            lastShotTime = 0;
        }
    }

    protected abstract void Shoot();
    
    public void SetOffset(Vector2 o)
    {
        offset = o;
    }
}
