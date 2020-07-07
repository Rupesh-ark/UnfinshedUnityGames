using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;   // A reference for the OG controller script basically allowing us to use it's funtions

    private float horizontalMove;           // A variable to store the axis value of horizontal movement (-1 or 1) (aka left or right)(there is one more version of it called getaxis, read about it )
    private bool jump = false;              // A variable to keep track of whether we are jumping or not
    private bool crouch = false;            // A variable to keep track of whether we are crouching or not
    float runSpeed = 40f;                   // A multiplier for movement

    public Animator animator;
    

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



    }

    public void Onlanding()
    {
        animator.SetBool("isJumping", false);

    }


    //This function is called a fixed amount of time, Basically every 0.02 seconds so that the movement is done regardless of frame rate.
    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

        

    }

}
