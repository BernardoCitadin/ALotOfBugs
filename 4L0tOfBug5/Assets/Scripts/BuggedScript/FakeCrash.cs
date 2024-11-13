using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FakeCrash : MonoBehaviour
{
    public Image blueScreenImage;

    private void Start()
    {
        StartCoroutine(TimerToActivePanel());
    }
    public IEnumerator TimerToActivePanel()
    {
        print("voiice");
        float time = Random.Range(15f, 30f);
        print(time);
        yield return new WaitForSeconds (time);
        blueScreenImage.enabled = true;
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        blueScreenImage.enabled = false;
        StartCoroutine(TimerToActivePanel());
    }
}
