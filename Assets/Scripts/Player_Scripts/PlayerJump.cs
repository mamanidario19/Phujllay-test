using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    private CharacterController player;
    [SerializeField] private float jumpForce;
    private bool jump; //neseraio para disparar la animacion de salto
    public bool Jump {get {return jump;} set{jump = value;}}
    private bool floor; //necesario para dispara la animacin de idle
    public bool Floor {get {return floor;} set{floor = value;}}
    private void Start() {
        player = GetComponent<CharacterController>();
    }
    
    private void Update() {
        Jumping();
    }

    private void Jumping() {
        if (Input.GetButtonDown("Jump") && player.isGrounded) {
            Vector3 moveDirection = new Vector3(0,jumpForce,0);
            player.Move(moveDirection * Time.deltaTime);
            jump = true;
            floor = false;
        } else {
            jump = false;
            floor = true;
        }
    }
}