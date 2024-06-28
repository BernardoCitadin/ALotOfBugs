using UnityEngine;

public class LaggingBug : MonoBehaviour
{
    public void LagMutation()
    {
        Application.targetFrameRate = 10;
    }
}
