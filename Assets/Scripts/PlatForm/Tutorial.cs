using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    [Header("Start/End Tutorial")]
    public bool start = false;
    public bool middle = false;
    public bool end = false;

    [Header("Disappear")]
    public GameObject currentTTrigger;
    public GameObject currentTArrow;

    //For Middle and End
    public GameObject tutorialTask;



    [Header("Appear")]
    public GameObject nextTTrigger;
    public GameObject nextTArrow;
    public GameObject TButton;
    public GameObject actualTutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (start == true)
            {
                nextTTrigger.gameObject.SetActive(true);
                nextTArrow.gameObject.SetActive(true);

                tutorialTask.gameObject.SetActive(true);

                currentTArrow.gameObject.SetActive(false);
                currentTTrigger.gameObject.SetActive(false);
            }

            if (middle == true)
            {
                nextTTrigger.gameObject.SetActive(true);

                actualTutorial.gameObject.SetActive(true);
                TButton.gameObject.SetActive(true);

                tutorialTask.gameObject.SetActive(false);

                currentTArrow.gameObject.SetActive(false);
                currentTTrigger.gameObject.SetActive(false);
            }

            if (end == true)
            {
                TButton.gameObject.SetActive(true);

                actualTutorial.gameObject.SetActive(true);
                currentTTrigger.gameObject.SetActive(false);
            }
        }
    }  
}