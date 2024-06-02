using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public FloatingJoystick joystick;

    public float speed = 5;

    public static float direction;

    public Animator animator;

    public static Transform posPlayer;
    public SpriteRenderer spriteRenderer;
    public static PlayerMovement Instance;

    //public Transform weapon;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        posPlayer = transform;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (joystick.Horizontal != 0)
        {
            direction = joystick.Horizontal;
        }

        if (joystick.Horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (joystick.Horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("Walking", joystick.Horizontal != 0 || joystick.Vertical != 0);

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
}
