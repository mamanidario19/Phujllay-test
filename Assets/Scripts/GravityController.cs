using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private CharacterController player;
    private PlayerMovement character;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] public float fallVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        character = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
    }
    private void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = - gravity * Time.deltaTime;
            character.direction.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            character.direction.y = fallVelocity;    
        }
    }
}
