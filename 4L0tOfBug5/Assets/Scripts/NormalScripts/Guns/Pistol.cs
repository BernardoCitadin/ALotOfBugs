using UnityEngine;

public class Pistol : Gun
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform bullets;

    Transform closeEnemy;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        anim = GetComponent<Animator>();
        lastShotTime = fireRate;
        print(bullets.name);
    }

    void Update()
    {
        transform.position = (Vector2)player.position + offset;
        FindCloseEnemy();
        Aim();
        Shooting();
    }
    protected override void Shoot()
    {
        var muzzleGo = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);

        var projectileGo = Instantiate(projectile, muzzlePosition.position, transform.rotation, bullets);
        Destroy(projectileGo, 3);
    }
}
