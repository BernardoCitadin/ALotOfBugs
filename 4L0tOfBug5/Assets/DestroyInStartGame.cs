using UnityEngine;

public class DestroyInStartGame : MonoBehaviour
{
    float timerEvilEvil = .2f;
    private void Update()
    {
        timerEvilEvil -= Time.deltaTime;
        if(timerEvilEvil <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}
