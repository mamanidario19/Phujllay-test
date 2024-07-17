using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_TrueRange : MonoBehaviour
{
    private float posY;
    public float PosY { get { return posY;} set { posY = value; } }
    private Vector3 posRange;
    private void Awake() {
        SetupVariables();
    }
    public void SetupVariables () {
        posY = Random.Range(0f,3f);
        posRange = new Vector3(0f,posY,0f);
        this.transform.localPosition = posRange;
    }
}
