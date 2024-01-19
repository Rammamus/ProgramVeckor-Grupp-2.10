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

    /*
    public float sprintSpeed;
    public float walkSpeed;
    public float maxStamina;
    public float curStamina;
    bool isSprinting;*/
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    KeyCode sprintKey; //remember to use this later

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //curStamina = maxStamina;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        MyInput();
        /* sprint if we use later
        //changes the movement speed depending if you're sprinting or not - Adrian
        if (Input.GetKey(KeyCode.LeftShift) && curStamina > 0)
        {
            moveSpeed = sprintSpeed;
            curStamina -= Time.deltaTime;
            isSprinting = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
        } */
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

    /* Stamina regen if we use later
    //Starts regenerating stamina after a brief period after either running out or stopping - Adrian
    private void StaminaRegen()
    {
        if (!isSprinting)
        {
            float timer = 0;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                curStamina += Time.deltaTime;
            }
        }
    }*/
}