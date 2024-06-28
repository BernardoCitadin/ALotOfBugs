using UnityEngine;

public class InvertCameraBug : MonoBehaviour
{
    public Transform cvCamRotate;
    public Transform playerObj;

    private void Start()
    {
        Rotate();
    }
    public void Rotate()
    {
        cvCamRotate.Rotate(0, 0, 180, Space.Self);
        playerObj.Rotate(0, 0, 180, Space.Self);
    }
}
