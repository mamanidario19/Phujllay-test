using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SB_Slidebar : MonoBehaviour
{
    [SerializeField] public float vel;
    [SerializeField] private KeyCode button;
    [SerializeField] private SB_TrueRange range;
    public ChangeDirection changeDirection;
    private bool inRange;
    [SerializeField] private bool inTune;
    public bool incorrectPress;
    public int correctPressCount = 0;
    public int incorrectPressCount = 0;

    // GET - SET
    public float Vel { get { return vel; } set { vel = value; } }
    public bool InTune { get { return inTune; } set { inTune = value; } }

    private void Update() {

    }
    public void PointMovement() {
        this.transform.Translate(Vector3.up*vel*Time.deltaTime);
    }
    public void IsRangeStatus() {
        if(Input.GetKeyDown(button) && inRange) {
            
            inTune = true;
            CountCorrectPressure();
            range.SetupVariables();
            //Debug.Log("InTune " + inTune);
        }
        if (Input.GetKeyDown(button) && !inRange)
        {
            incorrectPress = true;
            CountIncorrectPressure();
            range.SetupVariables();
            //Debug.Log("IncorrectPress " + incorrectPress);
        }
    }

    public void CountCorrectPressure()
    {
        correctPressCount++;
        IncreasePointerVelocity();
        Debug.Log(correctPressCount);
    }

    public void CountIncorrectPressure()
    {
        incorrectPressCount++;
        DecreasePointerVelocity();
        Debug.Log(incorrectPressCount);
    }

    public void IncreasePointerVelocity()
    {        
        if (changeDirection.isMovingUp)
        {
            vel += 0.1f;
        }
        if (!changeDirection.isMovingUp)
        {
            vel -= 0.1f;
        }
    }

    public void DecreasePointerVelocity()
    {
        if (changeDirection.isMovingUp)
        {
            if (vel >= 0.2f)
            {
                vel -= 0.1f;
            }            
        }
        if (!changeDirection.isMovingUp)
        {
            if (vel <= -0.2f)
            {
                vel += 0.1f;
            }            
        }
    }

    public void ResetPointerVelocity()
    {
        if (changeDirection.isMovingUp)
        {
            vel = 0.1f;
        }
        if (!changeDirection.isMovingUp)
        {
            vel = -0.1f;
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