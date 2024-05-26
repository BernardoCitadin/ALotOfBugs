using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] int damage;
    float speed = 12f;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        }
    }
}
