using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    [SerializeField] private float jumpForce;
    [SerializeField] public bool jump; //neseraio para disparar la animacion de salto
    [SerializeField] public bool floor; //necesario para dispara la animacin de idle
    private Vector3 moveDirection;
    private CharacterController player; // otro script
   
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
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection = new Vector3(0,jumpForce,0);
            player.Move(moveDirection * Time.deltaTime);
            jump = true;
            floor = false;
        }
        else
        {
            jump = false;
            floor = true;
        }
    }
    void Fall ()
    {
        if (player.isGrounded!) floor = false;
        else floor = true;
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Jump();
        }
    }*/
}