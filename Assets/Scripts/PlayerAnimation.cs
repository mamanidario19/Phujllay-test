using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnim();
        JumpAnim();
    }

    private void MoveAnim()
    {
        anim.SetFloat("VelX", player.moveX);
        anim.SetFloat("VelY", player.moveZ);
    }
    private void JumpAnim()
    {
        anim.SetBool("Jump", player.jump);
        anim.SetBool("touchFloor", player.floor);
    }
}
