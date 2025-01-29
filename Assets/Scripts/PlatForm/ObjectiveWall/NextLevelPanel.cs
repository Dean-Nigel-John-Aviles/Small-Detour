using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelPanel : MonoBehaviour
{
    public GameObject EndCutsceneTrigger;
    public GameObject NextChapter;
    public float EndCutsceneDuration;

    private void Start()
    {
        EndCutsceneTrigger.SetActive(false);
        NextChapter.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
       {
            EndCutsceneTrigger.SetActive(true);
            Invoke("NextChapEnable", EndCutsceneDuration);
       }
    }

    private void NextChapEnable() 
    {
        NextChapter.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndCutsceneTrigger.SetActive(false) ;
            NextChapter.SetActive(false);
        }
    }
}
