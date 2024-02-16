
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private CharacterController player;
    [SerializeField] private float speed;
    [SerializeField] private float speedRun;
    private float turnTime; //tiempo de rotacion del personaje
    [SerializeField] private Transform camera;
    private Vector3 moveDir;
    private float turnVelocity; //velocidad de rotacion
    private float moveX;
    private float moveZ;
    private float aniMov;
    public float AniMov { get {return aniMov;} set {aniMov = value;} }
    

    void Start() {
        player = GetComponent<CharacterController>();
    }

    void Update() {
        Moving();
    }

    private void Moving() {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3 (moveX, 0, moveZ).normalized;    //la direccion del movimiento, a donde queremos ir

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;//angulo de movimineto en el eje cartesiano "X" y "Z" - calculo
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);//suaviza la rotacion del personaje
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;//actualiza la direccion en la que se orienta el
            transform.rotation =  Quaternion.Euler(0f, angle, 0f);//intaciar la rotacion

            player.Move(moveDir.normalized * speed * Time.deltaTime);//instancia el movimiento

            aniMov = 0.5f;

            Runing();
        } else aniMov = 0;
    }
    private void Runing () {
        if (Input.GetButton("Run")) {
            float running = speed + speedRun;
            player.Move(moveDir.normalized * running * Time.deltaTime);

            aniMov = 1f;
        }
    }
}
