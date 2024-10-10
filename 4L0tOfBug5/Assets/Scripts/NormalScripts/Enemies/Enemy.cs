using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public float life;
    public float speed;
    protected Rigidbody2D body;
    public GameObject xp;
    public float damage;
    public Transform _target;
    NavMeshAgent _agent;

    public static Enemy Instance;

    public int xpgain;

    public void Awake()
    {
        _target = EnemyManager.Instance.playerPosition;
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
    public void Movement()
    {
        _agent.SetDestination(_target.position);    
    }
    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            PlayerStats.GainXp(xpgain);

            if (Random.Range(0, 100) <= 25)
            {
                //Instantiate(xp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
