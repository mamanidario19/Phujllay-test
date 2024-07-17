using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;

public class Festival_PuzzlesController : MonoBehaviour
{
    [SerializeField] private GameObject CameraPuzzleToActivate, player, puzzle;
    private bool isPlaying = false;
    //[SerializeField] private GameObject player, puzzle;


    // GET -SET
    public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Disparar evento
                InteractOn();
            }
            
        }
    }
    private void InteractOn()
    {
        //Debug.Log("Entrando al puzzle ");
        isPlaying = true;
        CameraPuzzleToActivate.SetActive(true);
        player.SetActive(false);
        //puzzle.SetActive(true);
    }

    private void InteractOff()
    {
        //Debug.Log("Saliendo del puzzle");
        isPlaying = false;
        CameraPuzzleToActivate.SetActive(false);
        player.SetActive(true);
        //puzzle.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InteractOff();
        }
    }
    /*
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject player;

    // GET - SET
    public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }
    private void Update() {
        PuzzleState();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isPlaying = true;
            puzzle.SetActive(true);
            UpdateCamera(currentCamera1);
            player.SetActive(false);
        }
    }
    private void PuzzleState () {
        if (!isPlaying) {            
            UpdatePlayerCamera(playerCamera);
        }
    }*/
}
