using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic;
    private bool flag=false;

    public static MenuMusic instance;

    private void Awake() {
        if (instance == flag) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
        
    }
    public void PlayMusic() {
        menuMusic.Play();
    }
    public void StopMusic() {
        menuMusic.Stop();
    }
    public void DestroyAudio() {
        flag = true;
        Destroy(this.gameObject);
        
    }
}
