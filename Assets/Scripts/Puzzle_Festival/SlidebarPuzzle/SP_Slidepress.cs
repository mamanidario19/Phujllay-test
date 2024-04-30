using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SP_Slidepress : MonoBehaviour
{
    [SerializeField] private float velUp;
    [SerializeField] private float velDown;
    private float velConstant;
    private bool buttonPress;
    [SerializeField] private KeyCode button;
    //Contador
    private float addPoint=2, restPoint=1;
    [SerializeField] private float count;
    private void Update() {
        PointMovement();
        Win();
    }
    private void PointMovement(){
        if (Input.GetKeyDown(button)) buttonPress = true;
        else if (Input.GetKeyUp(button)) buttonPress = false;

        if (buttonPress) transform.Translate(Vector3.up*velUp*Time.deltaTime);
        else transform.Translate(Vector3.down*velDown*Time.deltaTime);

        if (transform.position.y > 3f) velUp=0;
        else velUp = velConstant;

        if(transform.position.y < 0f) transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Range") count += addPoint*Time.deltaTime;
    }
    private void Rest(){
        if(count>0) count-=restPoint;
        if(count<=0) count=0;
    }
    private void Win(){
        if(count>35) Debug.Log("win");
    }
}
