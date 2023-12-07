using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    //otro script
    private CharacterController player;
    //private GravityController grav;
    //salto
    //[SerializeField] public float moveY;
    [SerializeField] private float jumpForce;
    [SerializeField] public bool jump; //neseraio para disparar la animacion de salto
    [SerializeField] public bool floor; //necesario para dispara la animacin de idle

    [SerializeField] private Vector3 moveDirection;

    private void Start()
    {
        player = GetComponent<CharacterController>();
       // grav = GetComponent<GravityController>();
    }

    private void Update()
    {
        Jump();
       // Fall();
    }

    void Jump()
    {
        moveDirection = new Vector3(0,jumpForce,0);

        if (player.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.Move(moveDirection * Time.deltaTime);
                //fall = jumpForce;
                //moveDirection.y = fall;
                jump = true;
                floor = false;    
            }
            else
            {
                jump = false;
                floor = true;
            }
        }        
    }
    void Fall ()
    {
        if (player.isGrounded!)
        {
            floor = false;
        } 
        else 
        {
            floor = true;
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Jump();
        }
    }*/
}