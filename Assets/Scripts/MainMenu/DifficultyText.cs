using UnityEngine;
using UnityEngine.UI;

public class DifficultyText : MonoBehaviour
{
    public Text difficultyText;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    string Easy = "Easy";
    string Medium = "Medium";
    string Hard = "Hard";


    void Start()
    {
        easyButton.onClick.AddListener(SetEasyDifficulty);
        mediumButton.onClick.AddListener(SetMediumDifficulty);
        hardButton.onClick.AddListener(SetHardDifficulty);
    }

    void SetEasyDifficulty()
    {
        difficultyText.text = Easy;
    }

    void SetMediumDifficulty()
    {
        difficultyText.text = Medium;
    }

    void SetHardDifficulty()
    {
        difficultyText.text = Hard;
    }
}
