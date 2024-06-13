using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombo_Controller : MonoBehaviour
{

    [SerializeField] private int numPiece, totalPieces=1;
    [SerializeField] private bool isInstrumentCumplete = false;

    //GET - SET
    public int NumPiece { get { return numPiece; } set { numPiece = value; } }

    private void Update() {
        if (numPiece == totalPieces) {
            isInstrumentCumplete = true;
        }
    }

}
