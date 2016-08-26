using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Light))]
public class FlashingLight : MonoBehaviour
{

    public float FlashRate = 1.0f;

    float NextLightChange = 0.0f;
    bool LightOn = false;

    Light light;
    float LightIntensity;

    void Start()
    {
        light = GetComponent<Light>();
        LightIntensity = light.intensity;
    }

    void Update()
    {
        if (NextLightChange < Time.time)
        {
            LightOn = !LightOn;

            light.intensity = LightOn ? 0 : LightIntensity;
            NextLightChange = Time.time + FlashRate;
        }
    }
}

