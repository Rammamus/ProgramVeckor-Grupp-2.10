using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a script that moves the player in accordance to the direction it is facing - Adrian
public class PlayerMovement : MonoBehaviour
{
    //All variable relative to the movement - Adrian
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        MyInput();
    }

    //Checks the player's movement inputs - Adrian
    private void MyInput()
    {
        //Might be unnecessary but this is just so that if you hold 2 opposing movement keys you won't go in one of the directions - Adrian
        if (Input.GetKey(KeyBinds.moveLeft) ^ Input.GetKey(KeyBinds.moveRight))
        {
            if (Input.GetKey(KeyBinds.moveLeft))
            {
                horizontalInput = -1;
            }
            if (Input.GetKey(KeyBinds.moveRight))
            {
                horizontalInput = 1;
            }
        }
        else
        {
            horizontalInput = 0;
        }

        if (Input.GetKey(KeyBinds.moveForward) ^ Input.GetKey(KeyBinds.moveBackward))
        {
            if (Input.GetKey(KeyBinds.moveForward))
            {
                verticalInput = 1;
            }
            if (Input.GetKey(KeyBinds.moveBackward))
            {
                verticalInput = -1;
            }
        }
        else
        {
            verticalInput = 0;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //Declares the players movedirection with the orientation (which way the camera is facing) and the players inputs - Adrian
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); //Adds force in the previously calculated movedirection - Adrian
    }
}