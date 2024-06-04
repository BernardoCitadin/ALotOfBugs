using UnityEngine;

public class Shotgun : Gun
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform[] muzzlePosition;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform bullets;

    public SpriteRenderer spg;

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

        if (angle <= 90)
        {
            spg.flipY = true;
        }
        else if (angle > 90)
        {
            spg.flipY = false;
        }
    }

    protected override void Shoot()
    {
        var muzzleGo = Instantiate(muzzle, muzzlePosition[0].position, transform.rotation, player);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);

        var projectileGo = Instantiate(projectile, muzzlePosition[0].position, transform.rotation, bullets);
        var projectileGo1 = Instantiate(projectile, muzzlePosition[1].position, transform.rotation, bullets);
        var projectileGo2 = Instantiate(projectile, muzzlePosition[2].position, transform.rotation, bullets);

        Destroy(projectileGo, 0.3f);
        Destroy(projectileGo1, 0.3f);
        Destroy(projectileGo2, 0.3f);
    }
}
