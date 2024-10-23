using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvaScale : MonoBehaviour
{
    public UnityEvent OnCanved;
    public void ScaleCanva(CanvasScaler canvas)
    {
        canvas.uiScaleMode = (CanvasScaler.ScaleMode)0;
    }
    public void DiscaleCanva(CanvasScaler canvas)
    {
        canvas.uiScaleMode = (CanvasScaler.ScaleMode)1;
    }

}
