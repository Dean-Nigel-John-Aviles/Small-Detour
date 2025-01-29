using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    public Slider slider;
    public Light sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        FindDirectionalLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneLight != null)
        {
            sceneLight.intensity = slider.value;
        }
        else
        {
            Debug.LogError("Directional Light is missing!");
        }
    }

    void FindDirectionalLight()
    {
        // Find the first directional light in the scene
        Light[] lights = FindObjectsOfType<Light>();
        foreach (Light light in lights)
        {
            if (light.type == LightType.Directional)
            {
                sceneLight = light;
                break;
            }
        }

        if (sceneLight == null)
        {
            Debug.LogWarning("No directional light found in the scene.");
        }
    }
}
