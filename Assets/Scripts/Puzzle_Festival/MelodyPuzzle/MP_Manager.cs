using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource audioInstrumental, audioMelodyChar;
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
        /*audioInstrumental= GetComponent<AudioSource>();
        audioMelodyChar = GetComponent<AudioSource>();*/
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
            audioInstrumental.Play();
            audioMelodyChar.Play();
        }
        
    }
    public void NoteHit(){
        currentScore+=scorePerNote;
        audioMelodyChar.mute = false;
    }
    public void NoteMissed(){
        badScore-=scorePerNote;
        audioMelodyChar.mute = true;
        Debug.Log("Missed");
        //currentScore-=scorePerNote;
    }
}
