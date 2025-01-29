using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTriggers : MonoBehaviour
{
    [Header("Panel of Task")]
    public GameObject Task;

    [Header("Blocker")]
    public GameObject Blocker;

    private int PlayerEntered = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerEntered == 0)
        {
            if (other.CompareTag("Player"))
            {
                Task.SetActive(true);
                Blocker.SetActive(true);
                PlayerEntered = 1;
            }
        }
    }
}
