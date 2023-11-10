using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //deplazamiento
    private float horizontalMove;
    private float verticalMove;
    
    [SerializeField] private CharacterController player;
    [SerializeField] private float playerSpeed;
    private Vector3 playerInput;
    private Vector3 movePlayer;
    //animacion
    private Animator anim;
    //private bool canJump;
    //movimiento de camara
    [SerializeField] private Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    //gravedad
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float fallVelocity; //sirve como controlador para que se ejecute bien la gravedad
    //salto
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        //canJump = false;
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        CameraDirection();

        movePlayer = playerInput.x *camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        anim.SetFloat("VelX",horizontalMove);
        anim.SetFloat("VelY",verticalMove);

        PlayerJump();
        SetGravity();

        player.Move(movePlayer * Time.deltaTime);
    }

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;       
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;    
            movePlayer.y = fallVelocity;
        }
    }

    void PlayerJump()
    {
            if (player.isGrounded && Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Jump",true);
                fallVelocity = jumpForce;
                movePlayer.y = fallVelocity;
            } else {
                Falling();
            }
            //anim.SetBool("tocoSuelo",true);
            
    }

    void Falling()
    {
        //anim.SetBool("tocoSuelo",false);
        anim.SetBool("Jump",false);
    }

    void CameraDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
