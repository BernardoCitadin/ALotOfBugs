using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : Gun
{
    [Header("Animator")]
    public Animator anim;
    protected override void Shoot()
    {
        anim.SetBool("Attacking", true);
        transform.position = Gun.Instance.closeEnemy.position;
    }

    private void FixedUpdate()
    {
        FindCloseEnemy();
        Aim();
        Shooting();
    }
}
