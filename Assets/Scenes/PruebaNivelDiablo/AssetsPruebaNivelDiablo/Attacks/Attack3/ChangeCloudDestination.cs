using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCloudDestination : MonoBehaviour
{
    public Transform destiny;
    public Transform personaje;

    void Start()
    {
        destiny = GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    public void ChangeToCharacterLocation()
    {
        destiny.transform.position = new Vector3(personaje.transform.position.x, personaje.transform.position.y, personaje.transform.position.z);
    }

    public void ChangeToHomeLocation()
    {
        destiny.transform.position = new Vector3(0f, 40f, 0f);
    }
}
