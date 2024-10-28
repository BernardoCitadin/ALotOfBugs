using UnityEngine;

public class StrechMainCharacter : MonoBehaviour
{
    Transform characterScale;
    float increaseScale = 1;
    private void Start()
    {
        characterScale = GetComponent<Transform>();
    }

    private void Update()
    {
        increaseScale += Time.deltaTime;

        characterScale.localScale = new Vector3(1, increaseScale, 1);
    }
}
