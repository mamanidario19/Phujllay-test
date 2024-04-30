using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "MP_ButtonActive") {
            Destroy(other.gameObject);
        }
    }
}
