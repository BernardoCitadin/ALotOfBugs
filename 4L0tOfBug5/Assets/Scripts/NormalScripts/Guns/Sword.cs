using UnityEngine;

public class Sword : Gun
{
    [Header("Animator")]
    public Animator anim;
    protected override void Shoot()
    {
        print("bangbang");
        anim.SetBool("Attacking", true);
    }
    private void Awake()
    {
        Aim();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FindCloseEnemy();
        Aim();
        Shooting();
    }
}
