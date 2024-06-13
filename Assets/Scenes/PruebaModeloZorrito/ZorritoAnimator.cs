using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorritoAnimator : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk()
    {
        anim.SetBool("isWalking", true);
    }

    public void Idle()
    {
        anim.SetBool("isWalking", false);
    }

    public void Jump()
    {
        anim.SetTrigger("isJumping");
    }

    public void NotJump()
    {
        anim.ResetTrigger("isJumping");
    }

    public void Sniff()
    {
        anim.SetTrigger("isSniffing");
    }

    public void NotSniffing()
    {
        anim.ResetTrigger("isSniffing");
    }
}
