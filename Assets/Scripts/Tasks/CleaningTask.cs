using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the cleaning task - Adrian
public class CleaningTask : Tasks
{
    float cleaningProgress;
    [SerializeField] float cleaningTime;
    public override void DoTask()
    {
        base.DoTask();
        if (Input.GetKey(KeyBinds.interact))
        {
            cleaningProgress += Time.deltaTime;
            print(cleaningProgress);
        }
        if (cleaningProgress > cleaningTime)
        {
            taskDone = true;
        }
    }
}