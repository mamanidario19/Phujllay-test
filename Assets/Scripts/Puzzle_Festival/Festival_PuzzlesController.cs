using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;

public class Festival_PuzzlesController : MonoBehaviour
{
    [SerializeField] private GameObject CameraPuzzleToActivate, player, puzzle;
    public AuthorizePlayPuzzle authorizePlayPuzzle;
    public GameObject gameObjectTxt, interfacePuzzle, cartelSiyNo, uiGame, botonesInicioPuzzle;
    public int numBack;
    private bool isPlaying = false;
    public bool inCollision = false;
    
    //[SerializeField] private GameObject player, puzzle;


    // GET -SET
    public bool IsPlaying { get { return isPlaying; } set { isPlaying = value; } }

    private void Awake()
    {
        gameObjectTxt.SetActive(true);
        gameObjectTxt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollision = true;
            gameObjectTxt.SetActive(true);
            //if (Input.GetKeyDown(KeyCode.P))
            //{
            //    // Disparar evento
            //    InteractOn();
            //}            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            inCollision = false;
            gameObjectTxt.SetActive(false);
        }
    }
    private void InteractOn()
    {
        //Debug.Log("Entrando al puzzle ");
        isPlaying = true;
        interfacePuzzle.SetActive(true);
        CameraPuzzleToActivate.SetActive(true);
        player.SetActive(false);
        //puzzle.SetActive(true);
    }

    public void InteractOff()
    {
        //Debug.Log("Saliendo del puzzle");
        isPlaying = false;
        interfacePuzzle.SetActive(false);
        CameraPuzzleToActivate.SetActive(false);
        player.SetActive(true);
        //puzzle.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KeyEscape();
        }

        if (inCollision)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                InteractOn();
            }
        }

        if (authorizePlayPuzzle.thisObjectActive)
        {
            gameObjectTxt.SetActive(false);
        }
    }

    public void KeyEscape()
    {
        switch (numBack)
        {
            case 1:
                botonesInicioPuzzle.SetActive(false);
                cartelSiyNo.SetActive(true);
                break;
            case 2:
                uiGame.SetActive(false);
                cartelSiyNo.SetActive(true);
                break;
            case 3:

                break;
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
