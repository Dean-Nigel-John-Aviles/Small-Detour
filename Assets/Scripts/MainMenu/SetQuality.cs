using UnityEngine;

public class SetQualityLevel : MonoBehaviour
{
    private const string QualityPrefKey = "QualitySetting";

    private void Start()
    {
        // Load the saved quality setting
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, 2); // Default to Medium Quality (2)
        QualitySettings.SetQualityLevel(savedQualityLevel, true);
    }

    public void LowQ()
    {
        SetQuality(0); // Fastest Quality
    }

    public void MedQ()
    {
        SetQuality(2); // Simple Graphics
    }

    public void HighQ()
    {
        SetQuality(5); // Fantastic Graphics
    }

    private void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
        PlayerPrefs.SetInt(QualityPrefKey, qualityLevel);
        PlayerPrefs.Save();
    }

    void NotHappening()
    {
        // Use these for later if you want

        QualitySettings.SetQualityLevel(1, true); // Fast Quality
        QualitySettings.SetQualityLevel(3, true); // Good Graphics
        QualitySettings.SetQualityLevel(4, true); // Beautiful Graphics
    }
}
