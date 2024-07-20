using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToEnableCamera : MonoBehaviour
{
    public bool isPlaying;
    public GameObject CameraNivelToActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraNivelToActivate.SetActive(true);
        }
    }
}