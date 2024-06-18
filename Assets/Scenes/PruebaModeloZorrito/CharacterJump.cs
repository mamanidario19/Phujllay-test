using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public Rigidbody rb;
    public float forceJump = 3.8f;
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
    }
}