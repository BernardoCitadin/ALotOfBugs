using UnityEngine;

public class Pistol : Gun
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform bullets;
    public static Pistol instance;
    Animator anim;

    public SpriteRenderer spg;

    void Start()
    {
        instance = this;
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
        var muzzleGo = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);

        var projectileGo = Instantiate(projectile, muzzlePosition.position, transform.rotation, bullets);
        Destroy(projectileGo, 3);
    }
}
