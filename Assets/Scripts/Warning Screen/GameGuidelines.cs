using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGuidelines : MonoBehaviour
{
    public PanelTimer warning;
    public GameObject gameGuidelines;
    public GameObject warningScreen;

    public void BtnGGcontinue()
    {
        Debug.Log("BtnGGcontinue called.");
        gameGuidelines.SetActive(false);
        warning.SetWarningScreen(true);
        warningScreen.SetActive(true);
    }

    public void BtnGGexit()
    {
        Debug.Log("BtnGGexit called.");
        Application.Quit();
    }
}
