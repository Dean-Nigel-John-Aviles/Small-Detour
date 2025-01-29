using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficulty("Easy"));
        mediumButton.onClick.AddListener(() => SetDifficulty("Medium"));
        hardButton.onClick.AddListener(() => SetDifficulty("Hard"));
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("GameDifficulty", difficulty);
        PlayerPrefs.Save();
        Debug.Log("Difficulty set to: " + difficulty);
    }

    public static string GetDifficulty()
    {
        return PlayerPrefs.GetString("GameDifficulty", "Medium"); // Default to Medium if not set
    }
}
