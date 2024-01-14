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

    public void UpdateText()
    {
        print("bomba"); // this happens
        taskText.text = "- " + taskName + ": " + tasksCompleted + "/" + locations.Length.ToString();
        taskList.list[place] = taskText;
        if (tasksCompleted == locations.Length)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
            taskText.color = Color.gray;
        }
    }
}