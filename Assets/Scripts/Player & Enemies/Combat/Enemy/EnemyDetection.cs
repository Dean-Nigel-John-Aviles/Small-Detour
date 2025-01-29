using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public NavigationScript nav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nav.FC = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nav.FC = false;
        }
    }
}
