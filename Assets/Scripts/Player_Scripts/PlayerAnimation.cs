using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement moving;
    private PlayerJump jumping;

    void Start() {
        anim = GetComponentInChildren<Animator>();
        moving = GetComponent<PlayerMovement>();
        jumping = GetComponent<PlayerJump>();
    }

    void Update() {
        MoveAnim();
    }

    private void MoveAnim() {
        anim.SetFloat("movement", moving.AniMov);
        anim.SetBool("jump", jumping.AniMov);
    }
}
