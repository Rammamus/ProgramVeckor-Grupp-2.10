using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskList : MonoBehaviour
{
    public TextMeshProUGUI[] list;
    [SerializeField] TextMeshProUGUI text;

    public void UpdateText()
    {
        //text.text = string.Join("\n", list.ToString());
        text.text = list[0].ToString() + list[1].ToString();
    }
}