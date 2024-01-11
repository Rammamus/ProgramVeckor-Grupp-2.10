using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//This script handles an entire task with it's text UI and numbers - Adrian
public class TaskHandler : MonoBehaviour
{
    [SerializeField] GameObject[] locations;
    [SerializeField] TextMeshProUGUI taskText;
    [SerializeField] string taskName;
    public int tasksCompleted;
    // Start is called before the first frame update
    void Start()
    {
        tasksCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        taskText.text = "- " + taskName + ": " + tasksCompleted + "/" + locations.Length.ToString();
        if (tasksCompleted == locations.Length)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
            taskText.color = Color.gray;
        }
    }
}
