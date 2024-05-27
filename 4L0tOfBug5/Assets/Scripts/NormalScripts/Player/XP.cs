using UnityEngine;

public class XP : MonoBehaviour
{
    public int xpgain;
    Rigidbody2D body;
    bool isMagnetized;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMagnetized)
        {
            body.velocity = ((PlayerMovement.posPlayer.position - transform.position) * 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                PlayerStats.GainXp(xpgain);
                Destroy(gameObject);
                break;
            case "Magnetic":
                PlayerMovement.posPlayer = collision.transform;
                isMagnetized = true;
                break;
        }
    }
}
