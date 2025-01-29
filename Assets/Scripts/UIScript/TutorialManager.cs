using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial Panel")]
    public GameObject tutorialPanel;

    [Header("Tutorial")]
    public GameObject tutorialJoystick;
    public GameObject tutorialDodge;
    public GameObject tutorialJump;
    public GameObject tutorialAttack;
    public GameObject tutorialObjective;
    public GameObject tutorialHealthBar;

    [Header("Game Control")]
    public GameObject controlJoystick;
    public GameObject controlDodge;
    public GameObject controlJump;
    public GameObject controlAttack;
    public GameObject controlObjective;
    public GameObject controlHealthBar;
    public GameObject controlPause;

    [Header("Game Triggers")]
    public GameObject firstTrigger;
    public GameObject secondTrigger;
    public GameObject thirdTrigger;

    [Header("Tutorial Validation")]
    public GameObject tutorialValidation;

    

    public void TutorialAccepted() 
    {
        firstTrigger.SetActive(true);
        tutorialValidation.SetActive(false);
        tutorialHealthBar.SetActive(true);
        controlHealthBar.SetActive(true);
    }

    public void TutorialDecline()
    {
        firstTrigger.SetActive(false);
        secondTrigger.SetActive(false);
        thirdTrigger.SetActive(false);
        tutorialValidation.SetActive(false);
        controlJoystick.SetActive(true);
        controlDodge.SetActive(true);
        controlJump.SetActive(true);
        controlAttack.SetActive(true);
        controlObjective.SetActive(true);
        controlHealthBar.SetActive(true);
        controlPause.SetActive(true);
    }
}
