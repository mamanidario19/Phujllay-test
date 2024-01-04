using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    
    private float gravity = 9.8f;
    private float fallVelocity;
    private CharacterController player;

    void Start() {
        player = GetComponent<CharacterController>();
    }

    void Update() {
        SetGravity();
    }

    private void SetGravity() {
        Vector3 fall = new Vector3 (0,fallVelocity,0).normalized;
        if (!player.isGrounded) fallVelocity -= gravity * Time.deltaTime;
        else    fallVelocity = - gravity * Time.deltaTime;
        player.Move(fall * Time.deltaTime);
    }
}
