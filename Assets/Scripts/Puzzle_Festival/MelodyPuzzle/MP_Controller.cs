using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controller : MonoBehaviour
{
    [SerializeField] private GameObject player, cameraPuzzle;
    [SerializeField] private MP_CompletePuzzle puzzle;
    //[SerializeField] private MP_Manager manager;
    private void Update() {
        if (puzzle.IsCompleted)
        {
            Win();
        }
    }
    private void Win() {
        Debug.Log("WIIIIIN");
        player.SetActive(true);
        cameraPuzzle.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
