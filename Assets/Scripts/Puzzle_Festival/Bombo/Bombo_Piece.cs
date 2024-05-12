using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombo_Piece : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private KeyCode button;
    [SerializeField] private Bombo_Controller piece;
    //private float numPiece;
    private bool isTaken;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isTaken = true;
            if (Input.GetKeyDown(button) && isTaken) {
                piece.NumPiece++;
                puzzle.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //numPiece++;
                //isTaken=true;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            isTaken=false;
        }
    }
}
