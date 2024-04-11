using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement moving;
    private PlayerJump jumping;

    void Start()
    {
        anim = GetComponent<Animator>();
        moving = GetComponent<PlayerMovement>();
        jumping = GetComponent<PlayerJump>();
    }

    void Update()
    {
        MoveAnim();
        JumpAnim();
    }

    private void MoveAnim()
    {
        anim.SetFloat("VelX", moving.MoveX);
        anim.SetFloat("VelY", moving.MoveZ);
    }
    private void JumpAnim()
    {
        anim.SetBool("Jump", jumping.Jump);
        anim.SetBool("touchFloor", jumping.Floor);
    }
}
