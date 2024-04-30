using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_TrueRange : MonoBehaviour
{
    private float posY;
    private Vector3 posRange;
    private void Start() {
        
    }
    private void SetupVariables() {
        posY = Random.Range(0, 3);
        posRange = new Vector3(0f, posY, 0f);
        this.transform.localPosition=posRange;
    }
}
