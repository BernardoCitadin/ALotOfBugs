using System.Collections;
using UnityEngine;

public class MeleeWeapon : Gun
{
    [Header("Prefabs")]
    [SerializeField] GameObject muzzle;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform bullets;

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
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        anim.SetBool("Attacking", true);
        anim.SetBool("Attacking", false);

        yield return new WaitForSeconds(0.5f);
    }
}
