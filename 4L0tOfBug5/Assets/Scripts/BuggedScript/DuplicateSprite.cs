using System.Collections;
using UnityEngine;

public class DuplicateSprite : MonoBehaviour
{
    SpriteRenderer playerSpRenderer;
    private void Start()
    {
        playerSpRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(TimerToDuplicateSprite());
    }

    public IEnumerator TimerToDuplicateSprite()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(playerSpRenderer);
    }
}
