using UnityEngine;

public class PanelTimer : MonoBehaviour
{
    public GameObject WarningPanel;
    public bool WarningScreen;
    public Splash splash;
    private float panelActiveStartTime;

    private void Start()
    {
        if (WarningScreen)
        {
            Debug.Log("Starting with WarningScreen active.");
            panelActiveStartTime = Time.time;
        }
    }

    private void Update()
    {
        if (WarningScreen)
        {
            float elapsedTime = Time.time - panelActiveStartTime;
            Debug.Log("Elapsed Time: " + elapsedTime);

            // Check if the panel has been active for more than 4 seconds
            if (elapsedTime > 4f)
            {
                // Deactivate the panel
                Debug.Log("Deactivating WarningPanel.");
                WarningPanel.SetActive(false);
                splash.warningDone = true;
                WarningScreen = false;
            }
        }
    }

    public void SetWarningScreen(bool state)
    {
        WarningScreen = state;
        if (state)
        {
            Debug.Log("SetWarningScreen called with state = true");
            WarningPanel.SetActive(true);
            panelActiveStartTime = Time.time;
        }
        else
        {
            Debug.Log("SetWarningScreen called with state = false");
        }
    }
}
