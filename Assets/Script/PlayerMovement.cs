using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    private float horizontalMove;

    private bool jump = false;

    private bool crouch = false;

    float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
        } else if(Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
        }



    }

    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

        

    }

}
