using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//This script handles the variables and functions for the players sanity - Adrian
public class Sanity : MonoBehaviour
{

    [SerializeField] AudioSource galenMusik;
    [SerializeField] GameObject audioManager;

    //All the necessary variables for sanity - Adrian
    public float insanity;
    public float maxInsanity;
    public bool losingSanity;
    public bool gainingSanity;

    //post processing variables - Adrian
    public PostProcessProfile profile;
    public Vignette vignette;
    public float insanePercentage;

    void Start()
    {
        profile.TryGetSettings(out vignette);
        insanity = 1;
    }

    public void Update()
    {
        insanity = Mathf.Clamp(insanity, 0, maxInsanity); //restricts the insanity so it can go below 0 or above the max value - Adrian
        insanePercentage = insanity/maxInsanity; //Makes a "percentage" of how insane you are - Adrian
        if (insanePercentage > 0.5)
        {
            
            vignette.intensity.value = 0.5f;
        }
        else
        {
            vignette.intensity.value = insanePercentage;
        }
        ChangeSanity(Time.deltaTime * 10);

        /*if (insanePercentage >= 0.5)
        {
            print("testc");
            audioManager.GetComponent<AudioManager>().playMusic();
        }*/
    }

    //A function for changing insanity by 'x' amount (positive number to gain, negative to lose) - Adrian
    public void ChangeSanity(float x)
    {
        insanity += x;
    }
}
