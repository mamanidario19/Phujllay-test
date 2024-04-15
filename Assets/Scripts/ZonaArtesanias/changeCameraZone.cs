using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeCameraZone : MonoBehaviour
{
    public string triggerTag;
    public CinemachineVirtualCamera primaryCamera;
    public CinemachineVirtualCamera[] virtualCameras;

    private void Start(){
        SwitchToCamera(primaryCamera);
    }

    private void onTriggerEnter(Collider other){
        if ( other.CompareTag(triggerTag)){
            CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
            SwitchToCamera(targetCamera);
        }
    }

     private void SwitchToCamera(CinemachineVirtualCamera targetCamera){
        foreach( CinemachineVirtualCamera camera in virtualCameras){
            camera.enabled = camera == targetCamera;
        }
    }
}


