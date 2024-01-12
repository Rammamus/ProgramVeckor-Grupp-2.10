using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdial : MonoBehaviour
{
    public DialogueManager dia;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dia.inconversation)
        {
            dia.DisplayNextScentence();
        }
    }
}
