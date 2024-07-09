using UnityEngine;

public class Pistol : Gun
{
    [Header("Muzzle Settings")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform muzzlePosition;
    [Header("Bullets Settings")]
    [SerializeField] GameObject projectile;
    [SerializeField] Transform bullets;
    public static Pistol instance;
    Animator anim;

    //public SpriteRenderer spg;

    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullets = GameObject.FindGameObjectWithTag("Bullets").transform;
        anim = GetComponent<Animator>();
        lastShotTime = fireRate;
    }

    void FixedUpdate()
    {
        transform.position = (Vector2)player.position + offset;
        FindCloseEnemy();
        Aim();
        Shooting();
    }
    private void Update()
    {
        if (closeEnemy == null)
        {
            return;
        }
        if (closeEnemy.position.x > player.position.x)
        {
            gameObject.transform.localScale = new Vector3(.5f, .5f, 1);
        }
        if (closeEnemy.position.x < player.position.x)
        {
            gameObject.transform.localScale = new Vector3(.5f, -.5f, 1);
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
