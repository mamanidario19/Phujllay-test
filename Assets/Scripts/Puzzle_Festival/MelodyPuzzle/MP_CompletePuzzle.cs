using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CompletePuzzle : MonoBehaviour
{
    [SerializeField] private bool isCompleted = false;
    // GET - SET
    public bool IsCompleted { get { return isCompleted; } }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "MP_Destroy") {
            isCompleted = true;
        }
    }
}
