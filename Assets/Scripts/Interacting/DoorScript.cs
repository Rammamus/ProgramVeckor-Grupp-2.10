using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for door - Adrian
public class DoorScript : MonoBehaviour
{
    bool doorOpen;

    public void DoorToggle()
    {
        if (doorOpen)
        {
            //close animation
            doorOpen = false;
            Debug.Log("This door got closed!");
        }
        else
        {
            //open animation
            doorOpen = true;
            Debug.Log("This door got opened!");
        }
    }
}
