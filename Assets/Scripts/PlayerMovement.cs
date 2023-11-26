using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public CharacterController player;
    [SerializeField] private float speed;
    [SerializeField] private float turnTime;//tiempo de rotacion del personaje
    private float turnVelocity; //velocidad de rotacion
    [SerializeField] public float moveX;
    [SerializeField] public float moveZ;
    [SerializeField] public Vector3 direction;
    [SerializeField] private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        //la direccion del movimiento, a donde queremos ir
        direction = new Vector3 (moveX, 0, moveZ).normalized;

        // si se esta moviendo
        if (direction.magnitude >= 0.1f)
        {
            //angulo de movimineto en el eje cartesiano "X" y "Z" - calculo
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //suaviza la rotacion del personaje
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);

            //actualiza la direccion en la que se orienta el
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //intaciar la rotacion
            transform.rotation =  Quaternion.Euler(0f, angle, 0f);
            //instancia el movimiento
            player.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            player.Move(direction * Time.deltaTime);   
        }
    }
}
