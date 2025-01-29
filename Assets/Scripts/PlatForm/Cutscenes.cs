using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public bool cutsceneplayed = false;
    public GameObject PlayerCam;
    public GameObject CutsceneCam;
    public GameObject PlayerPanel;
    public float DurationVid;
    public AudioSource BGM;

    private void Start()
    {
        PlayerCam.SetActive(true);
        CutsceneCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cutsceneplayed == false) 
        {
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
        PlayerPanel.SetActive(true);
        PlayerCam.SetActive(true);
        BGM.Play();
        CutsceneCam.SetActive(false);
    }
}
