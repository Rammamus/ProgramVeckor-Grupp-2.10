using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//This script is for the tasklist TextMeshPro element - Adrian
public class TaskList : MonoBehaviour
{
    public TextMeshProUGUI[] list;
    string[] listString;
    [SerializeField] TextMeshProUGUI text;
    
    //A function to update the text on screen - Adrian
    public void UpdateText()
    {
        listString = list.Select(TextMeshPro => TextMeshPro.text).ToArray(); //From TMPro array to string array - Adrian
        text.text = string.Join("\n", listString); //Makes the text on screen into the string array, hopping down a line for each new elemnt in the array - Adrian
    }
}