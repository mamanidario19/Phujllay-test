using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SB_Slidebar : MonoBehaviour
{
    [SerializeField] private float vel;
    //[SerializeField] private int count;
    //[SerializeField] private float constVel;
    [SerializeField] private KeyCode button;
    private bool inRange;
    private bool buttonPress;
    [SerializeField] private bool inTune;

    // GET - SET
    public float Vel { get { return vel; } set { vel = value; } }
    //public float ConstVel { get { return constVel; } set { constVel = value; } }
    public bool InTune { get { return inTune; } set { inTune = value; } }

    private void Start() {
        buttonPress = false;
        inRange = false;
        inTune = false;
    }
    private void Update() {
        //IsPressedButton();
        PointMovement();
        IsRangeStatus();
    }
    private void PointMovement() {
        this.transform.Translate(Vector3.up*vel*Time.deltaTime);
        if (this.transform.localPosition.y > 3f) vel = vel * -1;
        if (this.transform.localPosition.y < 0f) vel = vel * -1;
    }
    private void IsPressedButton() {
        if (Input.GetKeyDown(button)) buttonPress =true;
        else if (Input.GetKeyUp(button)) buttonPress = false;
    }
    private void IsRangeStatus() {
        if(Input.GetKeyDown(button) && inRange) {
            inTune = true;
        }
        /*if (buttonPress && inRange) {
            inTune = true;
            //Win();
        }*/
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Range") {
            inRange=true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Range")
        {
            inRange = false;
        }
    }
    /*private void Win() {
        inTune = true;
    }*/
}
