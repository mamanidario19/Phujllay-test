using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource song1; // La primera canci�n
    public AudioSource song2; // La segunda canci�n

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusicGuitar()
    {
        // Inicia la reproducci�n de las canciones
        song1.Play();
        song2.Play();
    }
}
