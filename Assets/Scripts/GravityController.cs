using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float fallVelocity;
    private CharacterController player;
    private PlayerMovement character;
    private float gravity = 9.8f;

    void Start()
    {
        player = GetComponent<CharacterController>();
        character = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        SetGravity();
    }

    private void SetGravity()
    {
        if (!player.isGrounded) fallVelocity -= gravity * Time.deltaTime;
        
        character.Direction = new Vector3 (0,fallVelocity,0);
    }
}
