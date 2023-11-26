using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement moving;
    private PlayerJump jumping;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        moving = GetComponent<PlayerMovement>();
        jumping = GetComponent<PlayerJump>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnim();
        JumpAnim();
    }

    private void MoveAnim()
    {
        anim.SetFloat("VelX", moving.moveX);
        anim.SetFloat("VelY", moving.moveZ);
    }
    private void JumpAnim()
    {
        anim.SetBool("Jump", jumping.jump);
        anim.SetBool("touchFloor", jumping.floor);
    }
}
