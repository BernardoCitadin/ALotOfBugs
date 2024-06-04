using UnityEngine;
using UnityEngine.UIElements;

public abstract class Gun : MonoBehaviour
{
    public Transform player;

    [SerializeField] public float fireDistance;
    [SerializeField] public float fireRate;

    public Vector2 offset;
    SpriteRenderer spg;
    
    public float lastShotTime;
    Transform closeEnemy;

    public static Gun Instance;

    public float angle;
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
        else
        { 
        transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected virtual void Shooting()
    {
        if (closeEnemy == null) return;

        lastShotTime += Time.deltaTime;
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
