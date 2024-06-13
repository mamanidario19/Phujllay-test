using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_ButtonController : MonoBehaviour
{
    private bool isPressed;
    [SerializeField] private KeyCode keyPressed;
    private void Update() {
        if(Input.GetKeyDown(keyPressed)) {
            if(isPressed) {
                gameObject.SetActive(false);
                MP_Manager.instance.NoteHit();
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "MP_ButtonActive") isPressed=true;
        if (other.tag == "MP_Destroy") {
            gameObject.SetActive(false);
            //MP_Manager.instance.NoteMissed();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "MP_ButtonActive") {
            isPressed=false;
            MP_Manager.instance.NoteMissed();
        }
    }
}
