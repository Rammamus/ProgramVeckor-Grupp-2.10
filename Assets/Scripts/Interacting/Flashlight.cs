using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    bool flashlightOn;
    [SerializeField] GameObject flashOn;
    [SerializeField] GameObject flashOff;

    void toggleFlashlight()
    {
        FindObjectOfType<AudioManager>().PlaySFX(FindObjectOfType<AudioManager>().ficklampa);
        if (flashlightOn == true)
        {
            flashOn.SetActive(false);
            flashOff.SetActive(true);
            flashlightOn = false;
        }
        else
        {
            flashOn.SetActive(true);
            flashOff.SetActive(false);
            flashlightOn = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flashlightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null && Input.GetKeyDown(KeyBinds.useItem))
        {
            toggleFlashlight();
        }
    }
}
