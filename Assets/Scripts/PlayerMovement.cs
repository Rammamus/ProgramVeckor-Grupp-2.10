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

    //Checks the player inputs to move - Adrian
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //Declares the players move direction and adds force in that direction - Adrian
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
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