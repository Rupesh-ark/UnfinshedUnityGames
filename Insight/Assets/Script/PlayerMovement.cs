using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;   // A reference for the OG controller script basically allowing us to use it's funtions.
    public Animator animator;               // A reference to animator so that, I can alter it's value from this script.

    private float horizontalMove;           // A variable to store the axis value of horizontal movement (-1 or 1) (aka left or right)(there is one more version of it called getaxis, read about it )
    private bool jump = false;              // A variable to keep track of whether we are jumping or not
    private bool crouch = false;            // A variable to keep track of whether we are crouching or not
    private float runSpeed = 40f;           // A multiplier for movement
    private bool dash = false;              // A bool for dash

    private float dashTime;                 //Time counter
    public float startDashTime = 5f;

    private void Start()
    {
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if(Input.GetKeyDown(KeyCode.S))    // Will make a dedicated button in unity for crouching like there is one for jump(the code above)
        {
            crouch = true;
           
        } else if(Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;   
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash = true;
        }
    }
    public void Onlanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
    private void DashImplement()                //For dashing
    {
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            dash = false;
        }
        else
        {
            dashTime -= Time.fixedDeltaTime;
        }
    }
    //This function is called a fixed amount of time, Basically every 0.02 seconds so that the movement is done regardless of frame rate.
    private void FixedUpdate()
    {
        //Debug.Log(dashTime);  For error checking in future
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, dash);
        jump = false;
        DashImplement();
    }
}
