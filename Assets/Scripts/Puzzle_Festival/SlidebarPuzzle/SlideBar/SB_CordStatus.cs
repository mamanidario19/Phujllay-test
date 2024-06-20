using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SB_CordStatus : MonoBehaviour
{
    [SerializeField] private GameObject cord;
    [SerializeField] private SB_Slidebar slidebar;
    [SerializeField] private SB_Controller controller;

    private void Update() {
        ChangeCord();
    }
    private void ChangeCord(){
        if(slidebar.InTune){
            cord.SetActive(true);
            controller.Count++;
            slidebar.InTune = false;
            this.gameObject.SetActive(false);
        } else if (slidebar.InTune && controller.Count == (controller.Cord-1) )
        {
            controller.Count++;
            slidebar.InTune = false;
            this.gameObject.SetActive(false);
        }
    }
}