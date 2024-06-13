using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Controller : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float maxPoint;
    private SP_Slidepress point;
    private void Update() {
        
    }
    private void EnableObjects() {
        gameObject.SetActive(false);
    }
    private void CountToWin() {
        if(point.Point == maxPoint) {
            Win();
        }
    }
    private void Win() {

    }

}
