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
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (Input.GetKeyDown(button)) {
                piece.NumPiece++;
                puzzle.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                //numPiece++;
                //isTaken=true;
            }
        }
    }
}
