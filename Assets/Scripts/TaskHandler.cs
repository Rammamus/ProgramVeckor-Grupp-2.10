using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script handles an entire task with it's text UI and numbers - Adrian
public class TaskHandler : MonoBehaviour
{
    [SerializeField] GameObject[] locations;
    [SerializeField] TextMeshProUGUI taskText;
    [SerializeField] TaskList taskList;
    [SerializeField] string taskName;
    [SerializeField] int place;
    public int tasksCompleted;

    void Start()
    {
        tasksCompleted = 0;
        UpdateText();
    }

    //A function for updating this specific task's list text - Adrian
    public void UpdateText()
    {
        taskText.text = "- " + taskName + ": " + tasksCompleted + "/" + locations.Length.ToString();
        taskList.list[place].text = taskText.text;
        taskList.UpdateText(); //Updates the final tasklist that is the one seen on screen - Adrian
    }
}