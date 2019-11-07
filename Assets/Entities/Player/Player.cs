using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //walking spead
    public float walkSpeed;

    //jumping speed
    public float jumpForce;

    //coin playing sound
    public AudioSource coinSound;

    //Rigidbody component
    Rigidbody rb;

    //Collider component
    Collider col;

    //flag to keep track of key pressing
    bool pressedJump = false;

    //size of the player
    Vector3 size;

    float hAxis;
    float vAxis;
    float jAxis;
    public int playerID;

    // Use this for initialization
    void Start()
    {
        // Grab our components
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        // get player size
        size = col.bounds.size;

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkHandler();
        JumpHandler();
    }


    public void CheckMovementInput()
    {      
        // Input on x (Horizontal)
        hAxis = Input.GetAxis("PJ"+ playerID + "_Horizontal");

        // Input on z (Vertical)
        vAxis = Input.GetAxis("PJ"+ playerID + "_Vertical");
       
    }

    public void CheckJumpInput()
    {

        // Input on z (Vertical)
        jAxis = Input.GetAxis("PJ"+ playerID + "_Jump");
        
    }
    // Takes care of the walking logic
    void WalkHandler()
    {

        CheckMovementInput();
        // Movement vector
        Vector3 movement = new Vector3(hAxis * walkSpeed * Time.deltaTime, 0, vAxis * walkSpeed * Time.deltaTime);

        // Calculate the new position
        Vector3 newPos = transform.position + movement;

        // Move
        rb.MovePosition(newPos);
    }

    // takes care of the jumping logic
    void JumpHandler()
    {
        // Input on the Jump axis
        CheckJumpInput();

        // If the key has been pressed
        if (jAxis > 0)
        {
            bool isGrounded = CheckGrounded();

            //make sure we are not already jumping
            if (!pressedJump && isGrounded)
            {
                pressedJump = true;

                //jumping vector
                Vector3 jumpVector = new Vector3(0, jAxis * jumpForce, 0);

                //apply force
                rb.AddForce(jumpVector, ForceMode.VelocityChange);
            }
        }
        else
        {
            //set flag to false
            pressedJump = false;
        }
    }

    // will check if the player is touching the ground
    bool CheckGrounded()
    {
        // location of all 4 corners
        Vector3 corner1 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, size.z / 2);
        Vector3 corner3 = transform.position + new Vector3(size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-size.x / 2, -size.y / 2 + 0.01f, -size.z / 2);

        // check if we are grounded
        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.01f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.01f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.01f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.01f);

        return (grounded1 || grounded2 || grounded3 || grounded4);
    }


    public Vector3 GetSize()
    {
        return size;
    }
}
