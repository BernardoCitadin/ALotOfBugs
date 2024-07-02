using UnityEngine;

public class LaggingBug : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        LagMutation(60);
    }
    private void OnBecameVisible()
    {
        LagMutation(10);
    }
    public void LagMutation(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }
}
