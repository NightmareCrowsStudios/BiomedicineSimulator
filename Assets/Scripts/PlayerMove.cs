using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float distanceGround = 0.4f;
    public LayerMask groundMask;

    Vector3 gravitySpeed;
    bool isGround;
    public bool walking;
    bool walkingBack;
    bool walkingLeft;
    bool walkingRight;
    //public Animator animMove;
    public Animator animObjects;

    void Start()
    {
        speed = walkSpeed;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animObjects.Play("animHands");
        }

        /////////////////////// COMANDO PARA OLHAR ITEM NA MÃO ///////////////////////////////////////////

        /*
        if(Input.GetKey(KeyCode.Mouse1) && !walking && !walkingBack && !walkingLeft && !walkingRight)
        {
            animMove.SetBool("armMove", true);
        }
        else
        {
            animMove.SetBool("armMove",false);
        }*/

        

        ///////////////////// MOVIMENTO/CORRER ////////////////////////////
        
        if(Input.GetKey(KeyCode.LeftShift) && isGround)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        ////////////////////// GRAVIDADE/PULO ///////////////////////////////////////

        isGround = Physics.CheckSphere(groundCheck.position, distanceGround, groundMask);

        if(isGround && gravitySpeed.y < 0)
        {
            gravitySpeed.y = -4f;
        }

        /////////////////////// MOVIMENTO ////////////////////////////////////

         float x = Input.GetAxis("Horizontal");
         float z = Input.GetAxis("Vertical");

         //Debug.Log(x);
         //Debug.Log(z);
         
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //////////////////// ANIMAÇÃO ////////////////////////
        
        

        /////////////////////// COMANDO PARA PULO /////////////////////////////

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            //animMove.Play("jumping");           
            gravitySpeed.y = Mathf.Sqrt(jumpHeight * -2f * gravity);           
        }

        gravitySpeed.y += gravity * Time.deltaTime;

        controller.Move(gravitySpeed * Time.deltaTime);
    }
}
