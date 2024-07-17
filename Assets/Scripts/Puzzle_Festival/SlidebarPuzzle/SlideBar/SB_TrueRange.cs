using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_TrueRange : MonoBehaviour
{
    public GameObject incorrectZone;
    private float posY;
    public float PosY { get { return posY;} set { posY = value; } }
    private Vector3 posRange;
    public bool isSetupDone = false;
    private void Awake() {
        SetupVariables();
    }
    public void SetupVariables () 
    {
        posY = Random.Range(0f, 3f);
        posRange = new Vector3(0f, posY, 0f);
        //this.transform.localPosition = posRange;
        //incorrectZone.transform.localPosition = posRange;
    }

    public void SetVariable()
    {
        this.transform.localPosition = posRange;
    }

    void Update()
    {
        incorrectZone.transform.localPosition = this.transform.localPosition;
    }
}