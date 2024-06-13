using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public CharacterJump characterJump;
    public CharacterCrouch characterCrouch;
    public CharacterMovement characterMovement;
    //public CharacterAnimator characterAnimator;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (characterJump.canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //characterAnimator.Jump();
                characterJump.Jump();
            }

            if (Input.GetKey(KeyCode.C))
            {
                //characterAnimator.IsCrouch();
                characterCrouch.IsCrouch();
            }
            else
            {
                //characterAnimator.IsNotCrouch();
                characterCrouch.IsNotCrouch();
            }

            //characterAnimator.TouchGround();
        }
        else
        {
            //characterAnimator.FallingDown();
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //characterAnimator.Run();
        characterMovement.Movement();
    }
}