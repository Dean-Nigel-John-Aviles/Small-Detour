using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        // Assuming you want to find the main camera in the scene
        cam = Camera.main?.transform;

        if (cam == null)
        {
            Debug.LogError("Main camera not found!");
        }
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            transform.LookAt(transform.position + cam.forward);
        }
        else
        {
            Debug.LogError("Camera is missing!");
        }
    }
}