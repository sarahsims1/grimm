using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brightness : MonoBehaviour
{

    public Light light;
    void Start()
    {
        RenderSettings.fogEndDistance = 150;
        RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f);
        RenderSettings.ambientIntensity = 0;
        light.intensity = 1;
    }

    public void UpdateLighting()
    {
        switch (staticStuff.getRuns() - staticStuff.goodFlags)
        {
            default:
                RenderSettings.fogEndDistance = 150;
                RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f);
                RenderSettings.ambientIntensity = 0;
                light.intensity = 1;
                break;
            case 2:
                RenderSettings.fogEndDistance = 80;
                RenderSettings.ambientLight = new Color(0.4f, 0.4f, 0.4f);
                RenderSettings.ambientIntensity = 0;
                light.intensity = 0.7f;
                break;
            case 3:
                RenderSettings.fogEndDistance = 70;
                RenderSettings.ambientLight = new Color(0.4f, 0.4f, 0.4f);
                RenderSettings.ambientIntensity = 0;
                light.intensity = 0.5f;
                break;
            case 4:
                RenderSettings.fogEndDistance = 60;
                RenderSettings.ambientLight = new Color(0.3f, 0.3f, 0.3f);
                RenderSettings.ambientIntensity = 0;
                light.intensity = 0.4f;
                break;
        }

    }
}
