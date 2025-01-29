using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OutOfBoundRestart : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to activate/deactivate

    private void Start()
    {
        // Ensure the panel is initially inactive
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger zone, activate the panel
            panel.SetActive(true);
        }
    }
}
