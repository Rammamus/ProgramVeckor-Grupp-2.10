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
        }
        else
        {
            //open animation
            doorOpen = true;
        }
    }
}
