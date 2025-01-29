using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGameTrigger : MonoBehaviour
{
    [Header("Panel Display")]
    public GameObject Panel;
    public GameObject Task;
    public GameObject Blocker;

    private int PlayerEntered = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Did not entered!!");
        if (PlayerEntered == 0)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Entered");
                Panel.SetActive(true);
                Task.SetActive(true);
                Blocker.SetActive(true);
                PlayerEntered = 1;
            }
        }
    }
}
