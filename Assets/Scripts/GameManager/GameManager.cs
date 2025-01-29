using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerLevel;
    public Vector3 playerPosition;
    public List<string> playerInventory;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pattern
    public PlayerData playerData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        // Save player data using PlayerPrefs or file system
        // Example using PlayerPrefs:
        string jsonData = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", jsonData);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            // Load player data using PlayerPrefs or file system
            // Example using PlayerPrefs:
            string jsonData = PlayerPrefs.GetString("PlayerData");
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Debug.LogWarning("No saved game data found.");
        }
    }
}