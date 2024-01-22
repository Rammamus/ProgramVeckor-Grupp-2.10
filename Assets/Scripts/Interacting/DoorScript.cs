using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the opening and closing of doors - Adrian
public class DoorScript : MonoBehaviour
{
    bool doorOpen;
    Animator animator;
    public bool locked;

    void Start()
    {
        doorOpen = true;
        animator = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    //Toggle for the door, if it's open -> close the door. if it's closed -> open the door - Adrian
    public void DoorToggle()
    {
        if (!locked)
        {
            if (doorOpen)
            {
                doorOpen = false;
                animator.Play("CloseDoor");
                animator.Play("CloseHandle");
            }
            else if (!doorOpen)
            {
                doorOpen = true;
                animator.Play("OpenDoor");
                animator.Play("OpenHandle");
            }
        }
    }
}
