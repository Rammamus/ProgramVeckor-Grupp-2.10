using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;
    

    void Start()
    {
      
        brightness.TryGetSettings(out exposure);
        if (PlayerPrefs.HasKey("Brightness"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        }
        else
        {
            brightnessSlider.value = 1;
        }
    }

    public void AdjustBrightness()
    {
        exposure.keyValue.value = brightnessSlider.value;
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.Save();
    }
}
