using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float life;
    public float speed;
    protected Rigidbody2D body;
    public GameObject xp;
    public float damage;
    public Transform _target;
    public Transform EnemyTransform;

    public static Enemy Instance;

    public int xpgain;

    private void Awake()
    {
        Instance = this;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            PlayerStats.GainXp(xpgain);

            if (Random.Range(0, 100) <= 25)
            {
                Instantiate(xp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
