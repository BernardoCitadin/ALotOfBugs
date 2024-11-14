using System.Collections;
using Unity.VisualScripting;
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
        float time = Random.Range(5f, 15f);
        print(time);
        yield return new WaitForSeconds (time);
        blueScreenImage.enabled = true;
        float waitTime = Random.Range(2f, 6f);
        yield return new WaitForSeconds(waitTime);
        blueScreenImage.enabled = false;
        StartCoroutine(TimerToActivePanel());
    }
}
