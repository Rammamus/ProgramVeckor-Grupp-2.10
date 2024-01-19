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

    private void Update()
    {

    }

    public void DoorToggle()
    {
        print(transform.position);
        if (doorOpen)
        {
            doorOpen = false;
            animator.Play("OpenDoor");
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
