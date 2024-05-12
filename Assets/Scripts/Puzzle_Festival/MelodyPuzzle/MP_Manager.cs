using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Manager : MonoBehaviour
{
    private bool starPlay;
    [SerializeField]private MP_BeatScroll beatScroll;
    [SerializeField] private int currentScore;
    [SerializeField] private int badScore;
    [SerializeField] private int scorePerNote = 1;
    [SerializeField] private KeyCode button;
    public static MP_Manager instance;
    
    // GET - SET
    //public int CurrentScore { get { return instance.currentScore;}}

    private void Start() {
        instance = this;
    }
    private void Update() {
        StartPuzzle();   
    }
    void StartPuzzle(){
        if (Input.GetKeyDown(button)){
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
        badScore-=scorePerNote;
        Debug.Log("Missed");
        //currentScore-=scorePerNote;
    }
}
