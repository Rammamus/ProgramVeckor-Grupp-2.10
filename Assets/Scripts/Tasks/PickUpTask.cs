using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the pickuptrash task - Adrian
public class PickUpTask : Tasks
{
    public override void DoTask()
    {
        base.DoTask();
        if (Input.GetKey(KeyCode.E)) //reemmeber - Adrian
        {
            taskDone = true;
        }
    }
}