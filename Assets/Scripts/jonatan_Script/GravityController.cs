using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private PlayerMovement play;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] public float fallVelocity;
    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
    }
    private void SetGravity()
    {
        if (play.player.isGrounded)
        {
            fallVelocity = - gravity * Time.deltaTime;
            play.direction.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            play.direction.y = fallVelocity;    
        }
    }
}
