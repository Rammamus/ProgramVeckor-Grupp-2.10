using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool flicker = false;
    float timedelay;
    public Sanity sanity;
    //reference ! - Erwin


    // Update is called once per frame
    void Update()
    {
        //om sanity �r 50% och flicker �r false, starta if-sattsen - Erwin
        if (sanity.insanePercentage >= 0.5 && flicker == false)
        {
            StartCoroutine(flickeringlight());

        }
        /*if (sanity.insanePercentage >= 0.8)
        {
            this.gameObject.GetComponent<Light>().enabled = false;
            flicker = true;
        }
        */
        
    }
    IEnumerator flickeringlight()
    {
        // Flicker = true, ljus obejektet st�ngs av, skapar random nummer. v�ntar random sekunder. s�tter p� ljus. - Erwin
        flicker = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
        // g�r samma sak igen och sedan s�tter flicker till false. - Erwin 
        this.gameObject.GetComponent<Light>().enabled = true;
        timedelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timedelay);
        flicker = false;
    }
}
