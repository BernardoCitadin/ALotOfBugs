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
        StartCoroutine(TimerWhileActivated());
    }
    public IEnumerator TimerWhileActivated()
    {
        print("easasasasasas");
        yield return new WaitForSeconds(Random.Range(.1f, 8f));
        blueScreenImage.enabled = false;
        StartCoroutine(TimerToActivePanel());
    }
}
