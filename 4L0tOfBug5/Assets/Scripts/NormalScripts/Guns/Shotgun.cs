using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform[] muzzlePosition;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform player;
    [SerializeField] Transform bullets;

    [Space(20)]

    [Header("Config")]
    [SerializeField] float fireDistance = 3f;
    [SerializeField] float fireRate = 1f;

    
    Vector2 offset;

    private float lastShotTime = 0;
    Transform closeEnemy;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        anim = GetComponent<Animator>();
        lastShotTime = fireRate;
    }

    void Update()
    {
        transform.position = (Vector2)player.position + offset;

        FindCloseEnemy();
        Aim();
        Shooting();

        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    void FindCloseEnemy()
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
    
    void Aim()
    {
        if(closeEnemy != null)
        {
            Vector3 direction = closeEnemy.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0,0,angle);

            transform.position = (Vector2)player.position + offset;
        }
        else
        { 
        transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Shooting()
    {
        if (closeEnemy == null) return;

        lastShotTime += Time.deltaTime;
        if (lastShotTime >= fireRate)
        {
            Shoot();
            lastShotTime = 0;
        }
    }

    void Shoot()
    {
        var muzzleGo = Instantiate(muzzle, muzzlePosition[0].position, transform.rotation, player);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);

        var projectileGo = Instantiate(projectile, muzzlePosition[Random.Range(0,4)].position, transform.rotation, bullets);
        var projectileGo1 = Instantiate(projectile, muzzlePosition[Random.Range(0, 4)].position, transform.rotation, bullets);
        var projectileGo2 = Instantiate(projectile, muzzlePosition[Random.Range(0, 4)].position, transform.rotation, bullets);

        Destroy(projectileGo, 1.5f);
        Destroy(projectileGo1, 1.5f);
        Destroy(projectileGo2, 1.5f);
    }
    
    public void SetOffset(Vector2 o)
    {
        offset = o;
    }
}
