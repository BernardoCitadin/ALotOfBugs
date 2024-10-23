using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject PopUpPrefab;

    public Transform[] TransformPoints;

    private void Start()
    {
        StartCoroutine(PopUpAppear());
    }
    IEnumerator PopUpAppear()
    {
        yield return new WaitForSeconds(Random.Range(2f, 10f));
        Instantiate(PopUpPrefab, Camera.main.transform).transform.position = new Vector2(Random.Range(TransformPoints[0].position.x, TransformPoints[1].position.x), Random.Range(TransformPoints[0].position.y, TransformPoints[1].position.y));
        StartCoroutine(PopUpAppear());

    }
}
