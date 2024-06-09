using UnityEngine;

public class Sword : Gun
{
    [Header("Animator")]
    public Animator anim;
    protected override void Shoot()
    {
        anim.SetBool("Attacking", true);
    }

    private void FixedUpdate()
    {
        FindCloseEnemy();
        Aim();
        Shooting();
    }
}
