using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//This script is for the tasklist - Adrian
public class TaskList : MonoBehaviour
{
    public TextMeshProUGUI[] list;
    string[] listString;
    public int completed;
    bool passedTheLevel;
    [SerializeField] TextMeshProUGUI text;
    
    //A function to update the progression of the tasklist - Adrian
    public void UpdateTaskBig()
    {
        listString = list.Select(TextMeshPro => TextMeshPro.text).ToArray(); //From TMPro array to string array - Adrian
        text.text = string.Join("\n", listString); //Makes the text on screen into the string array, hopping down a line for each new elemnt in the array - Adrian
    }

    public void EndOfDay()
    {
        if (completed == list.Length)
        {
            passedTheLevel = true;
        }
    }
}