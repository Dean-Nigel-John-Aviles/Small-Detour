using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCutscenes : MonoBehaviour
{
    public bool cutsceneplayed = false;
    public bool tutorial;
    public GameObject PlayerCam;
    public GameObject CutsceneCam;
    public GameObject PlayerPanel;
    public GameObject Tutorial;
    public float DurationVid;
    public AudioSource BGM;

    private void Start()
    {
        PlayerCam.SetActive(true);
        CutsceneCam.SetActive(false);
        Tutorial.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cutsceneplayed == false)
        {
            if (tutorial == true)
            { Tutorial.SetActive(false); }
            BGM.Pause();
            cutsceneplayed = true;
            PlayerPanel.SetActive(false);
            PlayerCam.SetActive(false);
            CutsceneCam.SetActive(true);
            Invoke("SwitchToPlayerCam", DurationVid);
        }
    }

    private void SwitchToPlayerCam()
    {
        Tutorial.SetActive(true);
        PlayerPanel.SetActive(true);
        PlayerCam.SetActive(true);
        BGM.Play();
        CutsceneCam.SetActive(false);
    }
}
