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
            Debug.Log("got brightness");
        }
        else
        {
            brightnessSlider.value = 2;
        }
    }

    public void AdjustBrightness()
    {
        exposure.keyValue.value = brightnessSlider.value;
        Debug.Log("is it even happening bro: " + exposure.keyValue.value + "    " + brightnessSlider.value); ;
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.Save();
    }
}
