using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContact : MonoBehaviour
{
    Transform cam;
    public float interactDistance = 5f;

    void Start()
    {
        cam = Camera.main.transform;    
    }

    void Update()
    {
        RaycastHit hit;
        
            if (Physics.Raycast(cam.position, cam.forward, out hit, interactDistance))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    {
                        print(hit.collider.name);
                    }
            print("foi");
            }
        
    }
}
