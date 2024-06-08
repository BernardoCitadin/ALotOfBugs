using UnityEngine;

public class Sword : Gun
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    protected override void Shoot()
    {

    }

    private void FixedUpdate()
    {
        FindCloseEnemy();
        Aim();

        anim.SetBool("Attacking", true);
        transform.position = Enemy.Instance.EnemyTransform.position;
        
    }
}
