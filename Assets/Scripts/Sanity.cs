using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//This script handles the variables and functions for the players sanity - Adrian
public class Sanity : MonoBehaviour
{
    //All the necessary variables for sanity - Adrian
    public float insanity;
    public float maxInsanity;
    public bool losingSanity;
    public bool gainingSanity;

    //post processing variables - Adrian
    public PostProcessProfile profile;
    public Vignette vignette;
    float insanePercentage;

    void Start()
    {
        profile.TryGetSettings(out vignette);
        insanity = 0;
        vignette.intensity.value = 0;
    }

    void Update()
    {
        insanity = Mathf.Clamp(insanity, 0, maxInsanity); //restricts the insanity so it can go below 0 or above the max value - Adrian
        insanePercentage = insanity/maxInsanity;
        vignette.intensity.value = insanePercentage;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeSanity(-10);
            print("go down       " + insanePercentage + "       " + insanity);

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ChangeSanity(10);
            print("go up       " + insanePercentage + "       " + insanity);
        }
    }

    //A function for changing sanity by 'x' amount (positive number to gain, negative to lose) - Adrian
    public void ChangeSanity(float x)
    {
        insanity += x;
    }
}
