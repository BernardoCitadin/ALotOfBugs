using UnityEngine;

public class Sword : Gun
{
    public AudioSource[] swordAudios = new AudioSource[0];
    [Header("Animator")]
    public Animator anim;
    protected override void Shoot()
    {
        print("bangbang");
        swordAudios[0].Play();
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
