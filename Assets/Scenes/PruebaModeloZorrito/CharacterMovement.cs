using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterInput characterInput;
    public Animator anim;

    //public CharacterAnimator characterAnimator;

    public float speedMov = 1.5f;
    public float speedRotate = 180.0f;
    public float decelerationRate = 0.1f;
    public float currentSpeed;

    //para saber si el pj esta idle o en mov
    public float x, y;

    //public Rigidbody rb;
    //public float forceJump = 5f;
    //public bool canJump;

    public float speed0;
    public float speedCouch;

    public bool isDecelerating = false;

    // Start is called before the first frame update
    void Start()
    {
        //canJump = false;
        speed0 = speedMov;
        speedCouch = speedMov * 0.5f;
        currentSpeed = speedMov;
    }
    void FixedUpdate()
    {
        //Queremos rotar o movernos dependiendo de x e y
        //transform.Rotate(0, x * Time.deltaTime * speedRotate, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * speedMov);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        //x = Input.GetAxis("Horizontal");
        //y = Input.GetAxis("Vertical");


        //if (canJump == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        //anim.SetBool("jump", true);
        //        rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
        //    }

        //    if (Input.GetKey(KeyCode.C))
        //    {
        //        //anim.SetBool("crouch", true);
        //        speedMov = speedCouch;
        //    }
        //    else
        //    {
        //        //anim.SetBool("crouch", false);
        //        speedMov = speed0;
        //    }

        //    //anim.SetBool("touchGround", true);
        //}
        //else
        //{
        //    //  Estoy cayendo
        //    fallingDown();
        //}
    }

    public void Movement()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Levantandose"))
        {
            // Aquí puedes agregar el código para que el zorrito se quede quieto
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkStart"))
        {
            // Aquí puedes agregar el código para que el zorrito empiece a moverse pero despacio
            transform.Translate(0, 0, characterInput.y * Time.deltaTime * 1f);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            // Aquí puedes agregar el código para que el zorrito empiece a moverse normalmente
            transform.Translate(0, 0, characterInput.y * Time.deltaTime * speedMov);
            currentSpeed = speedMov;
            isDecelerating = false;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkEnd"))
        {
            isDecelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //isDecelerating = true;
        }

        if (isDecelerating)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, decelerationRate * Time.deltaTime);
            if (currentSpeed < 0.01f) // puedes ajustar este valor
            {
                currentSpeed = 0;
                isDecelerating = false;
            }
        }
        //Queremos rotar o movernos dependiendo de x e y
        transform.Rotate(0, characterInput.x * Time.deltaTime * speedRotate, 0);       
    }
}
