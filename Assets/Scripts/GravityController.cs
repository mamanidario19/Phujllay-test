using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    
    /*private Vector3 fall;
    private float gravity = -9.8f;
    [SerializeField] private float gravityMulti = 3f;
    [SerializeField] private float speed;
    [SerializeField] private float fallVelocity;
    private CharacterController player;

    void Start() {
        player = GetComponent<CharacterController>();
    }

    void Update() {
        SetGravity();
    }

    private void SetGravity() {
        if (player.isGrounded && fallVelocity < 0.0f) {
            fallVelocity = -1.0f;
        } else {
            fallVelocity += gravity * gravityMulti * Time.deltaTime;
        }
        fall.y = fallVelocity;

        player.Move(fall * speed * Time.deltaTime);*/

        /*Vector3 fall = new Vector3 (0,fallVelocity,0).normalized;
        if (!player.isGrounded) fallVelocity -= gravity * Time.deltaTime;
        else    fallVelocity = - gravity * Time.deltaTime;
        player.Move(fall * speed * Time.deltaTime);
    }*/
}
