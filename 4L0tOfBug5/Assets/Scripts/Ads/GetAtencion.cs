using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAtencion : MonoBehaviour
{
    Image image;

    public Color[] colors;

    int currentColorIndex = 0;
    int targetColorIndex = 1;
    float targetPoint;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Transition();
    }

    void Transition()
    {
        targetPoint += Time.deltaTime;
        image.color = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if (targetColorIndex == colors.Length)
                targetColorIndex = 0;
        }
    }
}
