using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField] GameObject splash;

    public bool warningDone = false;

     void Update()
    {
        if (warningDone == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Invoke("LoadMainMenu", 0f);
            }
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
