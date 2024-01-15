using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The top of the heritage for tasks - Adrian
public class Tasks : MonoBehaviour
{
    [SerializeField] TaskHandler taskHandler;
    //[SerializeField] GameObject me;
    public bool interaction;
    public bool taskDone;
    void Update()
    {
        if (interaction)
        {
            DoTask();
        }
    }

    //A function for doing the task - Adrian
    public virtual void DoTask()
    {
        if (taskDone)
        {
            CompleteTask();
        }
    }

    //A function for if the task has to be stopped - Adrian
    public virtual void StopTask()
    {

    }

    //A function that gets used on completion of a task - Adrian
    public virtual void CompleteTask()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        taskHandler.tasksCompleted++;
        taskHandler.UpdateTask();
        interaction = false;
    }
}