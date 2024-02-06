using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchingTask : CleaningTask
{
    public override void DoTask()
    {
        base.DoTask();
    }

    public override void StopTask()
    {
        base.StopTask();
    }

    public override void CompleteTask()
    {
        taskHandler.tasksCompleted++;
        taskHandler.UpdateTask();
        interaction = false;
        FindObjectOfType<InteractibleRaycast>().interractText.SetActive(false);
        GetComponent<WrenchingTask>().enabled = false;
    }
}
