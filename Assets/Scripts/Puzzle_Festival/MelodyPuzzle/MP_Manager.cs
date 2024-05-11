using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Manager : MonoBehaviour
{
    private bool starPlay;
    [SerializeField]private MP_BeatScroll beatScroll;
    [SerializeField] private int currentScore;
    [SerializeField] private int scorePerNote = 1;
    public static MP_Manager instance;

    private void Start() {
        instance = this;
    }
    private void Update() {
        StartPuzzle();   
    }
    void StartPuzzle(){
        if (Input.anyKeyDown){
            if(!starPlay){
                starPlay = true;
                beatScroll.Started=true;
            }
        }
        
    }
    public void NoteHit(){
        currentScore+=scorePerNote;
    }
    public void NoteMissed(){
        Debug.Log("Missed");
        //currentScore-=scorePerNote;
    }
}
