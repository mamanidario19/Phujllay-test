using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCloudDestination : MonoBehaviour
{
    public Transform destiny;
    public Transform personaje;
    // Start is called before the first frame update
    void Start()
    {
        destiny = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToCharacterLocation()
    {
        destiny.transform.position = new Vector3(personaje.transform.position.x, personaje.transform.position.y + 1.5f, personaje.transform.position.z);
    }

    public void ChangeToHomeLocation()
    {
        destiny.transform.position = new Vector3(0f, 15f, 0f);
    }
}
