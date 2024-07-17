using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera currentCamera;
    //[SerializeField] private GameObject currentCanvan, targetCanvan;
    void Start()
    {
        currentCamera.Priority++ ;
    }

    public void UpdateCamera(CinemachineVirtualCamera target){
        currentCamera.Priority-- ;
        currentCamera=target;
        currentCamera.Priority++;
    }
    public void RunCanvan(GameObject targetCanvan) {
        targetCanvan.SetActive(true);
    }
    public void CloseCanvan(GameObject currentCanvan) {
        currentCanvan.SetActive(false);
    }
}
