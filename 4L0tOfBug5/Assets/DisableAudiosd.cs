using UnityEngine;

public class DisableAudiosd : MonoBehaviour
{
    public void DesactivateAudios()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
    }
}
