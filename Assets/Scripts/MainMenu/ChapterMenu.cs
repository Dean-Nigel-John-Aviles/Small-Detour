using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedChapter = PlayerPrefs.GetInt("UnlockedChapter", 1);
        //setting all buttons to false
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        //enables the buttons that is unlocked
        for (int i = 0; i < unlockedChapter; i++)
        {
            buttons[i].interactable = true;
        }
    }



    public void OpenChapter(int chapterId) 
    {
        string chapterName = "Chapter" + chapterId;
        SceneManager.LoadScene(chapterName);
    }
}
