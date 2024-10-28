using UnityEngine;

public class DuplicateSprite : MonoBehaviour
{
    SpriteRenderer playerSpRenderer;
    private void Start()
    {
        playerSpRenderer = GetComponent<SpriteRenderer>();

        Instantiate(playerSpRenderer);
    }
}
