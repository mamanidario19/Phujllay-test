using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Festival_PuzzleActive : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            InteractOn();
        }
    }
    private void InteractOn() {
        puzzle.SetActive(true);
    }
}
