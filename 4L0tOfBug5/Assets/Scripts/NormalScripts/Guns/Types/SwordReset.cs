using UnityEngine;

public class SwordReset : MonoBehaviour
{
    Animator anim;
    public Transform Sword;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ResetSword()
    {
        anim.SetBool("Attacking", false);
        transform.position = new Vector3 (0f, 0f, 0f);
    }
}
