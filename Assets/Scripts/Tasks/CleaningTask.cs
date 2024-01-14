using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTask : Tasks
{
    float cleaningProgress;
    [SerializeField] float cleaningTime;
    public override void DoTask()
    {
        base.DoTask();
        if (Input.GetKey(KeyCode.E))
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