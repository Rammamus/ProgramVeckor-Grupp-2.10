
// This script manages the brightness of the scene using a Slider UI element.-william
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    // Reference to the brightness slider UI element.-william
    public Slider brightnessSlider;
    // Reference to the Post Process Profile containing brightness settings.-william
    public PostProcessProfile brightness;
    // Reference to the Post Process Layer.-william
    public PostProcessLayer layer;

    // Reference to the AutoExposure effect.-william
    AutoExposure exposure;

    // Start is called before the first frame update-william
    void Start()
    {
        // Attempt to get the AutoExposure settings from the Post Process Profile.-william
        brightness.TryGetSettings(out exposure);

        // Check if there's a saved brightness value in PlayerPrefs.-william
        if (PlayerPrefs.HasKey("Brightness"))
        {
            // If there is a saved brightness value, set the slider's value to it.-william
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
            // Log that the brightness value has been retrieved.-william
            Debug.Log("Got brightness");
        }
        else
        {
            // If no brightness value is saved, set a default value.-william
            brightnessSlider.value = 2;
        }
    }

    // Method called when the brightness slider value changes.-william
    public void AdjustBrightness()
    {
        // Update the AutoExposure settings' key value with the slider's value.-william
        exposure.keyValue.value = brightnessSlider.value;
        // Log the current brightness values for debugging purposes.-william
        Debug.Log("Brightness values: Exposure - " + exposure.keyValue.value + ", Slider - " + brightnessSlider.value);

        // Save the current brightness value to PlayerPrefs for persistence.-william
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.Save();
    }
}
