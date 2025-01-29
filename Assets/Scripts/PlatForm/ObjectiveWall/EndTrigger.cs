using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject Blocker;
    public GameObject Startgt;
    public GameObject Endgt;
    public GameObject NextLevel;

    public bool LastLevel = false;
    public bool Ok = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nakapasok si player");
        if (Ok == true)
        {
            Debug.Log("Ok Si PLayer");
            if (LastLevel == false)
            {
                Debug.Log("Di Last LEvel");
                Blocker.SetActive(false);
                Startgt.SetActive(false);
                Endgt.SetActive(false);
                Ok = false;
            }
            else if (LastLevel == true)
            {
                Debug.Log("LastLEvel");
                Blocker.SetActive(false);
                Startgt.SetActive(false);
                Endgt.SetActive(false);
                NextLevel.SetActive(true);
                Ok = false;
            }
        }
        else if (Ok == false) 
        { 
            Debug.Log("Mali ka ng iniisip boi");
        }
    }
}
