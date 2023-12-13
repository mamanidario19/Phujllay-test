using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    private CharacterController player;
    [SerializeField] private float jumpForce;
    [SerializeField] public bool jump; //neseraio para disparar la animacion de salto
    [SerializeField] public bool floor; //necesario para dispara la animacin de idle
    
    private void Start() {
        player = GetComponent<CharacterController>();
    }
    
    private void Update() {
        Jump();
    }

    public void Jump() {
        if (Input.GetButtonDown("Jump")) {
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