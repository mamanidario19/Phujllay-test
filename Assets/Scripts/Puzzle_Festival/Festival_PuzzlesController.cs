using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;

public class Festival_PuzzlesController : MonoBehaviour
{
    private bool puzzle1 = false, puzzle2 = false, puzzle3 = false;
    [SerializeField] private CinemachineVirtualCamera currentCamera1, currentCamera2, currentCamera3;
    [SerializeField] private CinemachineFreeLook playerCamera;
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject player;

    private void Update() {
        PuzzleState();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Puzzle1") {
            puzzle1 = true;
            player.SetActive(false);
            UpdateCamera(currentCamera1);
        }
        if (other.tag == "Puzzle2") {
            puzzle2 = true;
            player.SetActive(false);
            UpdateCamera(currentCamera2);
        }
        if (other.tag == "Puzzle3") {
            puzzle3 = true;
            player.SetActive(false);
            UpdateCamera(currentCamera3);
        }
    }
    private void PuzzleState () {
        if (!puzzle1) {            
            UpdatePlayerCamera(playerCamera);
        }
        if (!puzzle2) {
            UpdatePlayerCamera(playerCamera);
        }
        if (!puzzle3) {
            UpdatePlayerCamera(playerCamera);
        }
    }
    private void UpdatePlayerCamera(CinemachineFreeLook camera) {
        playerCamera.Priority--;
        playerCamera = camera;
        playerCamera.Priority++;
    }
    private void UpdateCamera (CinemachineVirtualCamera target) {
        currentCamera1.Priority--;
        currentCamera1 = target;
        currentCamera1.Priority++;
    }
}
