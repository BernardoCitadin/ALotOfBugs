using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public FloatingJoystick joystick;

    public float speed = 5;

    public static float direction;

    //public Animator animator;

    public static Transform posPlayer;
    //public SpriteRenderer spriteRenderer;

    //public Transform weapon;

    void Start()
    {
        posPlayer = transform;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*

        if (horizontal != 0)
        {
            direction = horizontal;
        }

        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);

        weapon.localScale = new Vector2(direction, weapon.localScale.x);
        */

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
}
