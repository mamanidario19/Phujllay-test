using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    private CharacterController player;
    private Vector3 moveDirection;

    [SerializeField] private float jumpRange;
    [SerializeField] private float upVel;
    [SerializeField] private float downVel;
    private float jumpForce;
    private float gravity = -9.8f;
    
    [SerializeField] private Transform detectaPiso;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask mascaraPiso;

    private bool tocaPiso;

    private bool aniMov;
    public bool AniMov { get {return aniMov;} set{aniMov = value;} }
    private void Start() {
        player = GetComponent<CharacterController>();
    }
    
    private void Update() {
        Jumping();
    }

    private void Jumping() {
        tocaPiso = Physics.CheckSphere(detectaPiso.position,distancia,mascaraPiso);
        moveDirection = new Vector3(0,jumpForce,0);

        if (!tocaPiso) aniMov = true;  //moveDirection.y +=  gravity * Time.deltaTime;
        else aniMov = false;

        if (Input.GetButtonDown("Jump") && tocaPiso) {
            jumpForce = Mathf.Sqrt(jumpRange * upVel * gravity);
        }
        jumpForce += gravity * downVel * Time.deltaTime;

        player.Move(moveDirection * Time.deltaTime);
    }
}