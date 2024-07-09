using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Config")]
    public float damage = 1;
    [SerializeField]float speed = 12f;
    public static Bullet Instance;

    [Header("MeleeNPenetrate")]
    [SerializeField] bool IsMelee;
    [SerializeField] bool IsPrenetating;


    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && !IsMelee && !IsPrenetating)
        {
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        }
        if (enemy != null && !IsMelee && IsPrenetating)
        {
            enemy.TakeDamage(damage);
        }

        else if (enemy != null && IsMelee)
        {
            enemy.TakeDamage(damage);
        }

    }
}
