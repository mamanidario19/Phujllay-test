using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{ //variables de referencia
    PlayerInputs playerInput;
    CharacterController player;
    Animator animator;

    //variables para optimizar get/set de la animacion
    int isWalkHash;
    int isRunHash;
    int isJumpHash;

    //input variables de movimiento
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    Vector3 moveDir;
    //Vector3 apliedMovement;
    bool isMovementPressed;
    bool isRunPressed;

    //variables de movimiento actualizables
    [SerializeField] private float rotationFactorPerFrame = 4.0f;
    [SerializeField] private float runMultiplier = 4.0f;
    [SerializeField] private float walkMultiplier = 1.8f;

    //variables de camara
    [SerializeField] private Transform cameraTrans;
    Vector3 camForward;
    Vector3 camRight;

    //variables de gravedad
    float groundedGravity = -.05f;
    float gravity = -9.81f;

    //variables de salto
    bool isJumpPressed = false;
    float initialJumpVelocity;
    bool isJumping = false;
    bool isJumpAnimating = false;
    //variables de salto actuablizables
    [SerializeField] private float maxJumpHeight;
    [SerializeField] private float maxJumpTime;
    

    void Awake() {
        playerInput = new PlayerInputs();
        player = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        isWalkHash = Animator.StringToHash("isWalking");
        isRunHash = Animator.StringToHash("isRunning");
        isJumpHash = Animator.StringToHash("isJumping");

        playerInput.PlayerControls.Move.started += OnMovementInput;
        playerInput.PlayerControls.Move.canceled += OnMovementInput;
        playerInput.PlayerControls.Move.performed += OnMovementInput;
        playerInput.PlayerControls.Run.started += OnRun;
        playerInput.PlayerControls.Run.canceled += OnRun;
        playerInput.PlayerControls.Jump.started += OnJump;
        playerInput.PlayerControls.Jump.canceled += OnJump;

        setupJumpVariables();
    }

    void OnMovementInput(InputAction.CallbackContext context) {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x ;
        currentRunMovement.z = currentMovementInput.y ;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }
    void OnRun(InputAction.CallbackContext context) {
        isRunPressed = context.ReadValueAsButton();
    }
    void OnJump(InputAction.CallbackContext context) {
        isJumpPressed = context.ReadValueAsButton();
        //Debug.Log(isJumpPressed);
    }
    void setupJumpVariables() {
        float timeToApex = maxJumpTime/2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }
    void handleMovement() {
        //obtener movimiento relativo de la camara
        camForward = cameraTrans.forward;
        camRight = cameraTrans.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();
        //calcular direccion
        

        if (!isRunPressed){
            moveDir = (camForward * currentMovement.z)*walkMultiplier + (camRight * currentMovement.x)*walkMultiplier;
            moveDir.y = currentMovement.y;
            player.Move(moveDir * Time.deltaTime);
        } else {
            moveDir = (camForward * currentRunMovement.z)*runMultiplier + (camRight * currentRunMovement.x)*runMultiplier;
            moveDir.y = currentRunMovement.y;
            player.Move(moveDir * Time.deltaTime);
        }
    }
    void handleGravity() {
        bool isFalling = currentMovement.y <= 0.0f;
        float fallMultiplier = 2.0f;


        if (player.isGrounded)
        {
            if (isJumpAnimating)
            {
                animator.SetBool(isJumpHash,false);    
                isJumpAnimating = false;
            }
            
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        } else if (isFalling) {
            float previousYvelocity = currentMovement.y;
            float newYVelocity = currentMovement.y + (gravity * fallMultiplier * Time.deltaTime);
            float nextYVelocity = (previousYvelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
            currentRunMovement.y = nextYVelocity; 

        } else {
            float previousYvelocity = currentMovement.y;
            float newYVelocity = currentMovement.y + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYvelocity + newYVelocity) * .5f;
            currentMovement.y = nextYVelocity;
            currentRunMovement.y = nextYVelocity;

        }
    }
    void handleJump() {
        if (!isJumping && player.isGrounded && isJumpPressed) {
            animator.SetBool(isJumpHash,true);
            isJumpAnimating = true;
            isJumping = true;
            currentMovement.y = initialJumpVelocity * .5f;
            currentRunMovement.y = initialJumpVelocity * .5f;
        } else if (!isJumpPressed && isJumping && player.isGrounded) {
            isJumping = false;
        }
    }
    void handleRotation() {
        Vector3 positionToLookAt;
        positionToLookAt.x = moveDir.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = moveDir.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void handleAnimation() {
        bool isWalking = animator.GetBool(isWalkHash);
        bool isRunning = animator.GetBool(isRunHash);

        if (isMovementPressed && !isWalking) {
            animator.SetBool(isWalkHash, true);
        } else if (!isMovementPressed && isWalking) {
            animator.SetBool(isWalkHash,false);
        }

        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunHash,true);
        } else if ((!isMovementPressed || !isRunPressed) && isRunning) {
            animator.SetBool(isRunHash,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        handleAnimation();

        handleMovement();

        handleGravity();
        handleJump();
    }
    private void OnEnable() {
        playerInput.PlayerControls.Enable();
    }
    private void OnDisable() {
        playerInput.PlayerControls.Disable();
    }
}
