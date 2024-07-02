using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvPlayer : MonoBehaviour
{
    public SpriteRenderer playerSprite;

    void invPlayer(int collor)
    {
        Color color = new Color(1, 1, 1, collor);
        playerSprite.color = color;
    }
    private void OnBecameInvisible()
    {
        invPlayer(1);
    }
    private void OnBecameVisible()
    {
        invPlayer(0);
    }
}
