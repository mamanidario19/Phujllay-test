using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisable : MonoBehaviour
{
    public void DisableCamera(){
        this.gameObject.SetActive(false);
    }
}
