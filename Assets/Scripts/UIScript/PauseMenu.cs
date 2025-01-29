using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PlayerUIPanel;
    public GameObject PausePanel;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PlayerUIPanel.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        PlayerUIPanel.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerUIPanel.SetActive(true);
    }

    public void GoToChapter2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void GoToChapter3()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
