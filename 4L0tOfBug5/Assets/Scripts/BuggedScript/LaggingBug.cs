using UnityEngine;

public class LaggingBug : MonoBehaviour
{
    private void Start()
    {
        LagMutation();
    }
    public void LagMutation()
    {
        Application.targetFrameRate = 15;
    }
}
