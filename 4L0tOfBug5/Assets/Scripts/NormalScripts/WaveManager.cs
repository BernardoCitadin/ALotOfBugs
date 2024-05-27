using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText, waveText;
    public static WaveManager Instance;

    bool waveRunning = true;
    int currentWave = 0;
    int currentWaveTime;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        StartNewWave();
    }
    private void Start()
    {
        StartNewWave();
        timeText.text = "30";
        waveText.text = "Wave: 1";
    }

    public bool WaveRunning() => waveRunning;

    void StartNewWave()
    {
        StopAllCoroutines();
        timeText.color = Color.white;
        currentWave++;
        waveRunning = true;
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
        EnemyManager.Instance.DestroyAllEnemies();
        currentWaveTime = 30;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.red;
    }
}
