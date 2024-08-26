using UnityEngine;

public class Shotgun : Gun
{
    [Header("Muzzle Settings")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform[] muzzlePosition;
    [Header("Bullets Settings")]
    [SerializeField] public GameObject projectile;
    [SerializeField] Transform bullets;

    public AudioSource[] shotgunAudios = new AudioSource[0];

    //public SpriteRenderer spg;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        lastShotTime = fireRate;
    }

    void Update()
    {
        transform.position = (Vector2)player.position + offset;
        FindCloseEnemy();
        Aim();
        Shooting();

        if (closeEnemy == null)
        {
            return;
        }
        if (closeEnemy.position.x > player.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (closeEnemy.position.x < player.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, -1, 1);
        }
    }

    protected override void Shoot()
    {
        shotgunAudios[0].Play();
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
