using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText, waveText;
    public static WaveManager Instance;

    public UnityEvent EndWave;

    bool waveRunning = true;
    int currentWave = 0;
    int currentWaveTime;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    private void Start()
    {
        StartNewWave();
        timeText.text = "30";
        waveText.text = "Wave: 1";
    }

    public bool WaveRunning() => waveRunning;

    public void StartNewWave()
    {
        StopAllCoroutines();
        timeText.color = Color.white;
        currentWave++;
        waveRunning = true;
        UnPause();
        currentWaveTime = 30;
        waveText.text = "Wave: " + currentWave;
        StartCoroutine(WaveTimer());
    }

    IEnumerator WaveTimer()
    {
        while(waveRunning)
        {
            yield return new WaitForSeconds(1f);
            currentWaveTime--;

            timeText.text = currentWaveTime.ToString();

            if (currentWaveTime <= 0)
                WaveComplete();
        }
        yield return null;
    }
    void WaveComplete()
    {
        StopAllCoroutines();
        waveRunning = false;
        timeText.color = Color.red;
        EndWave.Invoke();
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
