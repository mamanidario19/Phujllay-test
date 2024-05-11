using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_BeatScroll : MonoBehaviour
{
    [SerializeField] private float beatTempo;
    private bool started;
    public bool Started { get { return started; } set { started = value; } }
    private void Start() {
        started = false;
        beatTempo = beatTempo/60f;
    }
    private void Update() {
        if (started) {
            transform.localPosition -= new Vector3(0f, 0f, beatTempo*Time.deltaTime);
        }
    }
}
