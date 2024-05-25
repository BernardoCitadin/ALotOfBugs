using UnityEngine;

public class Beetle : Enemy
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }
}
