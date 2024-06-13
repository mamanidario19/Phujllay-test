using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SB_Slidebar : MonoBehaviour
{
    [SerializeField] private float vel;
    [SerializeField] private KeyCode button;
    [SerializeField] private SB_TrueRange range;
    private bool inRange;
    [SerializeField] private bool inTune;

    // GET - SET
    public float Vel { get { return vel; } set { vel = value; } }
    public bool InTune { get { return inTune; } set { inTune = value; } }

    private void Update() {
        PointMovement();
        IsRangeStatus();
    }
    private void PointMovement() {
        this.transform.Translate(Vector3.up*vel*Time.deltaTime);
        if (this.transform.localPosition.y > 3f) vel = vel * -1;
        if (this.transform.localPosition.y < 0f) vel = vel * -1;
    }
    private void IsRangeStatus() {
        if(Input.GetKeyDown(button) && inRange) {
            
            inTune = true;
            range.SetupVariables();
            Debug.Log(inTune);
        }
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
