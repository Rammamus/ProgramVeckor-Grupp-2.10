using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for door - Adrian
public class DoorScript : MonoBehaviour
{
    bool doorOpen;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DoorToggle()
    {
        if (doorOpen)
        {
            doorOpen = false;
            animator.SetTrigger("Close");
            Debug.Log("This door got closed!");
        }
        else
        {
            doorOpen = true;
            animator.SetTrigger("Open");
            Debug.Log("This door got opened!");
        }
    }
}
