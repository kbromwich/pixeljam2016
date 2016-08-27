using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Light))]
public class FlashingLight : MonoBehaviour
{

    public float FlashRate = 1.0f;

    float NextLightChange = 0.0f;
    bool LightOn = false;

    Light LightToFlash;
    float LightIntensity;

    void Start()
    {
        LightToFlash = GetComponent<Light>();
        LightIntensity = LightToFlash.intensity;
    }

    void Update()
    {
        if (NextLightChange < Time.time)
        {
            LightOn = !LightOn;

            LightToFlash.intensity = LightOn ? 0 : LightIntensity;
            NextLightChange = Time.time + FlashRate;
        }
    }
}

